using System;
using UnityEngine;

namespace UI
{
    public class StartEscapeMenuController : MonoBehaviour
    {
        public Canvas pauseMenuCanvas;


        public void Start()
        {
            Time.timeScale = 0;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bool isActive = !pauseMenuCanvas.enabled;
                pauseMenuCanvas.enabled = isActive;
                Time.timeScale = isActive ? 0 : 1;
            }
        }
    }
}