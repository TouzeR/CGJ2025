using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Bosses
{
    public class Knight : Boss
    {
        private bool inCooldown = false;
        public int cooldown;
        
        List<int> listIntruments = new List<int>();

        void Start()
        {
            health = 10;
            listIntruments.Add(1);
            listIntruments.Add(2);
        }

        void Update()
        {
            if (health > 0)
            {
                Attack();
            }
        }
        
        protected async override void Attack()
        {
            if (inCooldown) return;

            inCooldown = true;

            Random rnd = new Random();
            int attack = rnd.Next(listIntruments.Count);
            
            await Task.Delay(cooldown);
            inCooldown = false;

        }
    }
}