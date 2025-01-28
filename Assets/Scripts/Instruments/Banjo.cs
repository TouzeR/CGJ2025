// Trompette.cs
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Banjo : Instrument
    {
        
        public Banjo()
        {
            name = "Banjo";
            key = KeyCode.J;
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