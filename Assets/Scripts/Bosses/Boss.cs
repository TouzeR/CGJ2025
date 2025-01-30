using System;
using System.IO.Pipes;
using Player;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

public abstract class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float damage;
    private HealthManager HealthManager;
    private bool isRespawning = false;
    public int level = 1;
    public TextMeshProUGUI score;

    public Animator animator;
    public ParticleSystem particleSystem;

    public Image wrapLevel;
    public TextMeshProUGUI levelText;


    
    public void Start()
    {
        HealthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        score.text = (level - 1).ToString();
        particleSystem.Stop();
        wrapLevel.enabled = false;
        levelText.enabled = false;
        DisplayLevel();

    }

    protected async void Update()
    {
    if (health > 0 && HealthManager.health > 0)
    {
        Attack();
    }
    else
    {
        if (!isRespawning)
        {
            animator.SetBool("isDead", true);
            isRespawning = true;
            //Respawn();
            particleSystem.Stop();
            await Task.Delay(5000);
            score.text = (level - 1).ToString();
            healthBar.SetMaxHealth(health);
            healthBar.SetHealth(health);
            isRespawning = false;
            animator.SetBool("isDead", false);
            DisplayLevel();
        }
    }
}

private async void Respawn()
{
    particleSystem.Stop();
    await Task.Delay(5000);
    health = maxHealth + level;
    level ++;
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

    protected abstract void Attack();
    
    
    public async void DisplayLevel()
    {
        wrapLevel.enabled = true;
        levelText.enabled = true;
        levelText.text = level.ToString();
        await Task.Delay(3000);
        wrapLevel.enabled = false;
        levelText.enabled = false;
    }
}

