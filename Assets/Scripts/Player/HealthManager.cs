using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        public float health;
        public List<Image> heartImages;

        public async void Start()
        {
            health = 3;
        }

        public void TakeDamage()
        {
            if (health > 0)
            {
                health -= 1;
                UpdateHeartUI();
            }
            else
            {
                Debug.Log("T'AS PERDU GROS NAZE");
                //TODO : Game Over
            }
        }

        public void Heal()
        {
            if (health < heartImages.Count)
            {
                health += 1;
                UpdateHeartUI();
            }
        }

        private void UpdateHeartUI()
        {
            for (int i = 0; i < heartImages.Count; i++)
            {
                heartImages[i].enabled = i < health;
            }
        }
    }
}