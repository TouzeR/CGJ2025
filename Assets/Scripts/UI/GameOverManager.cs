using System;
using UnityEngine;

namespace UI
{
    public class GameOverManager : MonoBehaviour
    {
        public GameObject gameOverPanel;
        public GameObject boutonGameOver;

        public void Update()
        {
            //TODO : bouton cliqué après mort pour relancer jeu MARCHE PAS
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject == boutonGameOver)
                    {
                        gameOverPanel.SetActive(false);
                    }
                }
            }
        }

        public void Start()
        {
            gameOverPanel.SetActive(false);
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}