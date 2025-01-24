// Flute.cs
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Flute : Instrument
    {
        public Flute()
        {
            name = "Flûte";
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


        public new void PlaySound()
        {
            base.PlaySound();
        }
    }
}