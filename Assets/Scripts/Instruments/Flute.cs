using System;
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Flute : Instrument
    {
        private new string name = "Flûte";
        private AudioClip sound;
        private Sprite image;
        private new KeyCode key = KeyCode.F;
        
        /**
         * On attribue les bonnes valeurs aux variables de la classe
         */
        public new void Start()
        {

        }
        
        public new void Stop()
        {
            // Stop the flute
        }
        
        public new void Update()
        {
            // Update the flute
        }
        
        
        
    }
}