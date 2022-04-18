using System;
using System.Collections.Generic;
using System.Linq;
namespace Assets.Scripts.UiElements.Sliders
{
    public class FixedCustomSlider : CustomSlider
    {
        protected override void Awake()
        {
            base.Awake();
            SetFixedValue();
        }

        private void SetFixedValue()
        {
            wholeNumbers = true;
        }
    }
}
