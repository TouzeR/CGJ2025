using System;
using Player;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float damage;
    private HealthManager HealthManager;

    
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
        if (health > 0 /*&& HealthManager.health > 1*/)
        {
            Attack();
        }
    }

    protected abstract void Attack();
}
