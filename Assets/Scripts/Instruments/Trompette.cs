using System;
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Trompette : Instrument
    {
        private new string name = "Trompette";
        private AudioClip sound;
        private Sprite image;
        private new KeyCode key = KeyCode.G;
        
        
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