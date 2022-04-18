using Assets.Scripts.Helpers;
using Assets.Scripts.UiElements.Interfaces;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Sliders
{   
    public class CustomSlider : Slider, ICustomSlider
    {              
        protected TextMeshProUGUI sliderValueText;

        protected TextMeshProUGUI sliderDescriptionText;

        protected float sliderValueMultiplier;

        protected const string currency = "$";

        protected void Awake()
        {            
            sliderValueText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Value));
            sliderDescriptionText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Description));

            SetValueText();          

            onValueChanged.AddListener(delegate { SetValueText(); });
        }

        public float GetTotalAmount()
        {
            return value * sliderValueMultiplier;
        }

        public SliderEvent GetSliderEvent()
        {
            return onValueChanged;
        }

        public void SetIntervalValues(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public void SetCurrentValue(float value)
        {
            this.value = value;
        }

        public float GetCurrentValue()
        {
            return this.value;
        }

        public void SetValueMultiplier(float sliderValueMultiplier)
        {
            this.sliderValueMultiplier = sliderValueMultiplier;
        }

        public void RefreshValueText()
        {
            SetValueText();
        }
        
        public void SetWholeNumbers()
        {
            wholeNumbers = true;
        }

        public void SetDescriptionText(string description)
        {
            sliderDescriptionText.text = description;
        }

        protected void SetValueText()
        {
            sliderValueText.text = GetTotalAmount().ToString() + currency;
        }      
    }
}
