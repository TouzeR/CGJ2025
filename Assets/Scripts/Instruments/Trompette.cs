using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Trompette : Instrument
    {
        private new void Start()
        {
            name = "Trompette";
            key = KeyCode.G;
            image = GetComponent<Image>();
            
            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}