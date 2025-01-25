using System.Collections.Generic;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        public float health;
        public List<Image> heartImages;
        public GameOverManager gameOverManager;
        public AudioClip damageSound;
        private AudioSource audioSource;

        public async void Start()
        {
            health = 6;
            gameOverManager = FindFirstObjectByType(typeof(GameOverManager)) as GameOverManager;

            if (gameOverManager == null)
            {
                Debug.LogError("GameOverManager n'a pas été trouvé dans la scène.");
            }

            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        public void TakeDamage()
        {
            if (audioSource != null && damageSound != null)
            {
                audioSource.clip = damageSound;
                audioSource.Play();
            }

            if (health > 1)
            {
                health -= 1;
                UpdateHeartUI();
            }
            else
            {
                health -= 1;
                Debug.Log("perdu");
                gameOverManager.GameOver();
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

        public void Reset()
        {
            health = 6;
            UpdateHeartUI();
        }
    }
}