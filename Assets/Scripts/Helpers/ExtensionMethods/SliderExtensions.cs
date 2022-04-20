using Assets.Scripts.UiElements.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.ExtensionMethods
{
    public static class SliderExtensions
    {
        public static void ConfigureSlider(this CustomSlider slider, float minValue, float maxValue, float currentValue, float valueMultiplier)
        {
            slider.SetIntervalValues(minValue, maxValue);
            slider.SetValueMultiplier(valueMultiplier);
            slider.SetCurrentValue(currentValue);
            slider.RefreshValueText();
        }
    }
}
