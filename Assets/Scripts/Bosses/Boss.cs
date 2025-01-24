using System;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    public float damage;

    
    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (health > 0)
        {
            Attack();
        }
    }

    protected abstract void Attack();
}
