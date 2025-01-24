// Trompette.cs
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Trompette : Instrument
    {
        
        public Trompette()
        {
            name = "Trompette";
            key = KeyCode.F;
        }

        void Start()
        {
            image = GetComponent<Image>();
            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}