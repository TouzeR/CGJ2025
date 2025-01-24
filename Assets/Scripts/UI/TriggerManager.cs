using UnityEngine;

namespace UI
{
    public class TriggerManager : MonoBehaviour
    {
        public GameObject gameOverPanel;
        
        public void OnButtonClick()
        {
            gameOverPanel.SetActive(false);
        }
    }
}