using System;
using System.IO.Pipes;
using Player;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public abstract class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float damage;
    private HealthManager HealthManager;
    private bool isRespawning = false;
    protected int level = 1;
    public TextMeshProUGUI score;

    public Animator animator;
    public ParticleSystem particleSystem;


    
    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        HealthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        score.text = (level - 1).ToString();
        particleSystem.Stop();

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
        if (!isRespawning)
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
    await Task.Delay(5000);
    health = maxHealth + level;
    level ++;
    score.text = (level - 1).ToString();
    healthBar.SetMaxHealth(health);
    healthBar.SetHealth(health);
    isRespawning = false;
    animator.SetBool("isDead", false);

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

    }

    protected abstract void Attack();
}
