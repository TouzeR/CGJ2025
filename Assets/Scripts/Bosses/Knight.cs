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
        private bool isAttacking = false;

        // La liste des classes d'instruments
        public Flute flute;
        public Trompette trompette;
        private List<Instrument> instruments = new List<Instrument>();

        void Start()
        {
            health = 10;
            instruments.Add(flute);
            instruments.Add(trompette);
            damage = 5;
        }

        void Update()
        {
            if (health > 0)
            {
                Attack();
            }
            else
            {
                Debug.Log("Dead");
            }
        }

        protected async override void Attack()
        {
            if (inCooldown) return;

            inCooldown = true;

            Random rnd = new Random();
            int attack = rnd.Next(instruments.Count);
            instruments[attack].PlaySound();
            Debug.Log("Attaque boss : " + instruments[attack].getKey());

            bool playerRespondedCorrectly = await WaitForPlayerResponse(instruments[attack].getKey());

            if (playerRespondedCorrectly)
            {
                health -= 1;
            }
            else
            {
                Debug.Log("Dégâts subis par le joueur !");
            }

            await Task.Delay(cooldown);
            inCooldown = false;

        }

        private async Task<bool> WaitForPlayerResponse(KeyCode expectedKey)
        {
            bool playerResponded = false;
            float timeLimit = 5f;
            float elapsedTime = 0f;

            while (elapsedTime < timeLimit)
            {
                if (Input.GetKeyDown(expectedKey))
                {
                    playerResponded = true;
                    break;
                }

                await Task.Yield();
                elapsedTime += Time.deltaTime;
            }

            return playerResponded;
        }
    }
}
