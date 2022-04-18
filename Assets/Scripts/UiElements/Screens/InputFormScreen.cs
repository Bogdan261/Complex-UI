using Assets.Scripts.UiElements.Sliders;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UiElements.Screens
{
    public class InputFormScreen : Screen
    {
        [SerializeField]
        private CustomSlider mainValueSlider;      

        private const float valueSliderMinValue = 1;
        private const float valueSliderMaxValue = 5;
        private const float sliderValueMultiplier = 40;

        private readonly List<string> causes = new List<string>()
        {
            "Redaction",
            "Nature"
        };

        private void Awake()
        {           
            ConfigureMainSlider();

            CreatePercentageSlidersForCauses();
            CreateCheckboxesForCauses();        

            PercentageDivisionSlidersScreen.Instance.enabled = true;
        }

        private void CreatePercentageSlidersForCauses()
        {
            foreach(var cause in causes)
            {
                PercentageDivisionSlidersScreen.Instance.InstantiatePercentageSlider(cause);
            }
        }

        private void CreateCheckboxesForCauses()
        {
            var i = 0;
            var percentage = 50f;

            foreach (var cause in causes) //here needs to be "cause package", not create a checkbox for every cause
            {
                var description = new List<string>();
                foreach (var cause2 in causes)
                {
                    description.Add((mainValueSlider.GetTotalAmount() * percentage / 100).ToString() + "$ for " + cause2);
                }
                ToggleGroupScreen.Instance.InstantiateToggle("More to " + cause, i == 0, description);
            }
        }

        private void ConfigureMainSlider()
        {
            mainValueSlider.SetWholeNumbers();

            ConfigureSlider(mainValueSlider, minValue: valueSliderMinValue, maxValue: valueSliderMaxValue, currentValue: 1, valueMultiplier: sliderValueMultiplier);        
        }      

        //this method is duplicate. Need to extract it further
        private void ConfigureSlider(CustomSlider slider, float minValue, float maxValue, float currentValue, float valueMultiplier)
        {
            slider.SetIntervalValues(minValue, maxValue);
            slider.SetValueMultiplier(valueMultiplier);
            slider.SetCurrentValue(currentValue);
            slider.RefreshValueText();
        }
    }
}
