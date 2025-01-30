using System;
using Bosses;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameplayManager : MonoBehaviour
    {
        private Boss knight;
        private Boss dragon;
        private Boss bossActuel;
        
        void Start()
        {
            knight = FindFirstObjectByType(typeof(Knight)) as Knight;
            //dragon = FindFirstObjectByType(typeof(Dragon)) as Dragon;
            dragon = null; //TODO: à enlever pour utiliser vraiment le dragon une fois fini

            //bossActuel = Random.Range(0, 2) == 0 ? knight : dragon; TODO : changer lors de la mise en place du dragon
            bossActuel = knight;
            
            DemarrerPartieBoss(); //TODO : changer lors de la mise en place des blocks
        }
        
        void Update()
        {
            if (bossActuel.health <= 0)
            {
                int level = bossActuel.level;
                int maxHealth = bossActuel.maxHealth;
                //bossActuel = bossActuel == knight ? dragon : knight; //TODO : changer lors de la mise en place du dragon
                bossActuel.level = level + 1;
                bossActuel.health = maxHealth + level;
            }
            
        }

        void DemarrerPartieBoss()
        {
            bossActuel.Start();
        }
        
        
        void DemarrerPartieBlocks()
        {
            throw new NotImplementedException("TODO !");
        }
    }
}