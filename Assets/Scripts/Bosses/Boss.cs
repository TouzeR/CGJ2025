using System;
using System.IO.Pipes;
using Player;
using UnityEngine;
using System.Threading.Tasks;

public abstract class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float damage;
    private HealthManager HealthManager;
    private bool isRespawning = false;
    protected int level = 1;

    public Animator animator;


    
    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        HealthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
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
    await Task.Delay(5000);
    health = maxHealth + level;
    level ++;
    healthBar.SetMaxHealth(health);
    healthBar.SetHealth(health);
    isRespawning = false;
    animator.SetBool("isDead", false);
    Debug.Log("Boss Respawned" + health + level);

}

public void Reset()
    {
        health = maxHealth;
        level = 1;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
        Debug.Log("Boss Reset" + health);

    }

    protected abstract void Attack();
}
