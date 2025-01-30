﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instruments;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Bosses
{
    public class Knight : Boss
    {

        private bool inCooldown = false;
        private int cooldown;
        private bool isAttacking = false;

        public Flute flute;
        public Trompette trompette;
        public Harpe harpe;
        public Violon violon;
        public Banjo banjo;
        public Ocarina ocarina;
        
        private List<Instrument> instruments = new List<Instrument>();

        private HealthManager healthManager;

        public async void Start()
        {
            maxHealth = 3;
            instruments.Add(flute);
            instruments.Add(trompette);
            instruments.Add(harpe);
            instruments.Add(violon);
            instruments.Add(banjo);
            instruments.Add(ocarina);
            damage = 5;
            
            Random rnd = new Random();
            cooldown = rnd.Next(6000, 12000);

            healthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;

            if (healthManager == null)
            {
                Debug.LogError("healthManager n'a pas été trouvé dans la scène.");
            }
            base.Start();
        }

        void Update()
        {
            base.Update();
        }

        protected async override void Attack()
        {
            //TODO le boss continue d'attaquer même si le joueur est mort !
            if (inCooldown) return;

            inCooldown = true;
            
            Random rnd = new Random();
            int attack = rnd.Next(instruments.Count);
            animator.SetBool("isAttacking",true);
            instruments[attack].PlaySound();
            Debug.Log("Attaque boss : " + instruments[attack].getKey());
            bool playerRespondedCorrectly = await WaitForPlayerResponse(instruments[attack].getKey());

            if (playerRespondedCorrectly)
            {
                particleSystem.Play();
                health -= 1;
                healthBar.SetHealth(health);
                Debug.Log("Health du boss : " + health);
                animator.SetBool("isAttacking",false);
            }
            else
            {
                healthManager.TakeDamage();
                animator.SetBool("isAttacking",false);
            }
            
            await Task.Delay(500);
            particleSystem.Stop();

            await Task.Delay(cooldown);
            inCooldown = false;
        }

        private async Task<bool> WaitForPlayerResponse(KeyCode expectedKey)
        {
            bool playerResponded = false;
            float timeLimit = 6f;   
            float elapsedTime = 0f;

            while (elapsedTime < timeLimit)
            {
                if (Input.GetKeyDown(expectedKey))
                {
                    playerResponded = true;
                    break;
                }

                if (Input.anyKeyDown && !Input.GetKeyDown(expectedKey))
                {
                    break;
                }

                await Task.Yield();
                elapsedTime += Time.deltaTime;
            }

            return playerResponded;
        }
    }
}