using Unity.VisualScripting;

namespace Player
{
    public class HealthManager
    {
        public float health;

        public void Start()
        {
            health = 3;
        }
        
        public void Update()
        {
            if (health <= 0)
            {
                //level.GameOver();
            }
        }
        
        public void TakeDamage()
        {
            health -= 1;
        }
        
        public void Heal()
        {
            health += 1;
        }
        
        
    }
}