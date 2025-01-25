// Trompette.cs
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Harpe : Instrument
    {
        
        public Harpe()
        {
            name = "Harpe";
            key = KeyCode.L;
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