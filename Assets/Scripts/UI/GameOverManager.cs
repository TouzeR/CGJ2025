using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class GameOverManager : MonoBehaviour
    {
        public GameObject gameOverPanel;
        public GameObject boutonGameOver;

        void Start()
        {
            if (boutonGameOver == null)
            {
                Debug.LogError("boutonGameOver n'est pas assigné dans l'inspecteur.");
            }

            gameOverPanel.SetActive(false);
        }

        

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}