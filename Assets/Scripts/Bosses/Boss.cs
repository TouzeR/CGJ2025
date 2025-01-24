using System;
using Player;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public float health;
    public float damage;
    private HealthManager HealthManager;

    
    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
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
