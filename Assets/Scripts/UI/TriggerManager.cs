using UnityEngine;
using Player;
using System.Threading.Tasks;
namespace UI
{
    public class TriggerManager : MonoBehaviour
    {
        public GameObject gameOverPanel;
        
        private Boss boss;

        private HealthManager healthManager;
        void Start()
        {
            healthManager = FindFirstObjectByType(typeof(HealthManager)) as HealthManager;
            boss = FindFirstObjectByType(typeof(Boss)) as Boss;
        }

        public void OnButtonClick()
        {
            gameOverPanel.SetActive(false);
            //TODO : Relancer le jeu
            healthManager.Reset();
            boss.Reset();
            


        }
    }
}