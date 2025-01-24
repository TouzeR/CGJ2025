using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Flute : Instrument
    {
        private new void Start()
        {
            name = "Flûte";
            key = KeyCode.F;
            image = GetComponent<Image>();
            
            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}