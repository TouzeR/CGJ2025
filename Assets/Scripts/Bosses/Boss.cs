using System;
using System.Collections.Generic;
using System.IO.Pipes;
using Player;
using UnityEngine;
using System.Threading.Tasks;
using Instruments;
using TMPro;
using UnityEngine.UI;
using Random = System.Random;

public class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    private HealthManager HealthManager;
    private bool isRespawning = false;
    protected int level = 1;
    public TextMeshProUGUI score;

    public Animator animator;
    public ParticleSystem particleSystem;

    public Image wrapLevel;
    public TextMeshProUGUI levelText;

    private bool inCooldown = false;
    private int cooldown;
    private bool isAttacking = false;

    // La liste des classes d'instruments
    public Flute flute;
    public Trompette trompette;
    public Harpe harpe;
    public Violon violon;
    public Banjo banjo;
    public Ocarina ocarina;

    private List<Instrument> instruments = new List<Instrument>();

    private HealthManager healthManager;


    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected async void Start()
    {
        
        maxHealth = 3;
        instruments.Add(flute);
        instruments.Add(trompette);
        instruments.Add(harpe);
        instruments.Add(violon);
        instruments.Add(banjo);
        instruments.Add(ocarina);

        isRespawning = false;
        Random rnd = new Random();
        cooldown = rnd.Next(6000, 12000);

        healthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;

        if (healthManager == null)
        {
            Debug.LogError("healthManager n'a pas été trouvé dans la scène.");
        }

        HealthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        score.text = (level - 1).ToString();
        particleSystem.Stop();
        wrapLevel.enabled = false;
        levelText.enabled = false;
        DisplayLevel();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (health > 0 && HealthManager.health > 0)
        {
            Attack();
        }
        else
        {
            if (!isRespawning && HealthManager.health > 0)
            {
                animator.SetBool("isDead", true);
                isRespawning = true;
                Respawn();
            }
        }
    }

    private async void Respawn()
    {
        particleSystem.Stop();
        await Task.Delay(6000);
        health = maxHealth + level;
        level++;
        score.text = (level - 1).ToString();
        healthBar.SetMaxHealth(health);
        healthBar.SetHealth(health);
        isRespawning = false;
        animator.SetBool("isDead", false);
        DisplayLevel();
    }

    public void Reset()
    {
        particleSystem.Stop();
        health = maxHealth;
        level = 1;
        score.text = "0";
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
        Debug.Log("Boss Reset" + health);
        DisplayLevel();
    }

    protected async void Attack()
    {
        if (inCooldown) return;

        inCooldown = true;

        Random rnd = new Random();
        int attack = rnd.Next(instruments.Count);
        animator.SetBool("isAttacking", true);
        instruments[attack].PlaySound();
        Debug.Log("Attaque boss : " + instruments[attack].getKey());
        bool playerRespondedCorrectly = await WaitForPlayerResponse(instruments[attack].getKey());

        if (playerRespondedCorrectly)
        {
            particleSystem.Play();
            health -= 1;
            healthBar.SetHealth(health);
            Debug.Log("Health du boss : " + health);
            animator.SetBool("isAttacking", false);
        }
        else
        {
            healthManager.TakeDamage();
            animator.SetBool("isAttacking", false);
        }

        await Task.Delay(500);
        particleSystem.Stop();

        await Task.Delay(cooldown);
        inCooldown = false;
    }


    public async void DisplayLevel()
    {
        wrapLevel.enabled = true;
        levelText.enabled = true;
        levelText.text = level.ToString();
        await Task.Delay(3000);
        wrapLevel.enabled = false;
        levelText.enabled = false;
    }

    private async Task<bool> WaitForPlayerResponse(KeyCode expectedKey)
    {
        bool playerResponded = false;
        float timeLimit = 6f;
        float elapsedTime = 0f;

        while (elapsedTime < timeLimit)
        {
            if (Input.GetKeyDown(expectedKey))
            {
                playerResponded = true;
                break;
            }

            if (Input.anyKeyDown && !Input.GetKeyDown(expectedKey))
            {
                break;
            }

            await Task.Yield();
            elapsedTime += Time.deltaTime;
        }

        return playerResponded;
    }
}