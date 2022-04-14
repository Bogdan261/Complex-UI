using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UiElements.Sliders
{
    public class FixedValueSlider : BasicSlider
    {
        protected override void Awake()
        {
            base.Awake();
            SetFixedValue();
        }

        private void SetFixedValue()
        {
            slider.wholeNumbers = true;
        }
    }
}
