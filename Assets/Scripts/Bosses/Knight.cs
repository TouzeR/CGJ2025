using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instruments;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Bosses
{
    public class Knight : Boss
    {
        private bool inCooldown = false;
        public int cooldown;

        // La liste des classes d'instruments
        public Flute flute;
        public Trompette trompette;
        private List<Instrument> instruments=new List<Instrument>();

        void Start()
        {
            health = 10;
            instruments.Add(flute);
            instruments.Add(trompette);
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
            int attack = rnd.Next(instruments.Count);
            instruments[attack].PlaySound();
            
            await Task.Delay(cooldown);
            inCooldown = false;

        }
    }
}