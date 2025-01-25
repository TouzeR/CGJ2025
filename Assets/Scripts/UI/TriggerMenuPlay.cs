using UnityEngine;

namespace UI
{
    public class TriggerMenuPlay : MonoBehaviour
    {
        public Canvas canvas;
        

        public void ReturnToGame()
        {
            canvas.enabled = false;
            Time.timeScale = 1;
        }
        
        public void QuitterJeu()
        {
            Application.Quit();
        }
    }
}