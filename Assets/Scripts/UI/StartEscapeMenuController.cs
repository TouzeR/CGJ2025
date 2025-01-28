using UnityEngine;

namespace UI
{
    public class StartEscapeMenuController : MonoBehaviour
    {
        public Canvas pauseMenuCanvas;
        public MonoBehaviour bossScript; // Référence au script du boss

        void Awake()
        {
            Time.timeScale = 0;
            bossScript.enabled = false;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bool isActive = !pauseMenuCanvas.enabled;
                pauseMenuCanvas.enabled = isActive;
                Time.timeScale = isActive ? 0 : 1;
                bossScript.enabled = !isActive;
            }
        }
    }
}