using UnityEngine;

namespace UI
{
    public class TriggerMenuPlay : MonoBehaviour
    {
        public Canvas canvas;
        public MonoBehaviour bossScript;
        

        public void ReturnToGame()
        {
            canvas.enabled = false;
            Time.timeScale = 1; 
            bossScript.enabled = true;
        }
        
        public void QuitterJeu()
        {
            Application.Quit();
        }
    }
}