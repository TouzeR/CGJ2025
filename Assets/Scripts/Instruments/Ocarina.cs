// Trompette.cs
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Ocarina : Instrument
    {
        
        public Ocarina()
        {
            name = "Ocarina";
            key = KeyCode.H;
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