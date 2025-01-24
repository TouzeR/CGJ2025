using System;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public float health;
    public float damage;

    
    //public Level level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
