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
        [SerializeField]
        protected string description;       
       
        protected TextMeshProUGUI sliderValueText;

        protected TextMeshProUGUI sliderDescriptionText;

        protected float sliderValueMultiplier;

        protected const string currency = "$";

        protected void Awake()
        {            
            sliderValueText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Value));
            sliderDescriptionText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Description));

            SetValueText();
            SetDescriptionText();

            onValueChanged.AddListener(delegate { SetValueText(); });
        }

        public float GetSliderAmount()
        {
            return value * sliderValueMultiplier;
        }

        public SliderEvent GetSliderEvent()
        {
            return onValueChanged;
        }

        public void SetSliderIntervalValues(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public void SetSliderCurrentValue(float value)
        {
            this.value = value;
        }

        public float GetSliderCurrentValue()
        {
            return this.value;
        }

        public void SetSliderMultiplier(float sliderValueMultiplier)
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
      
        protected void SetValueText()
        {
            sliderValueText.text = GetSliderAmount().ToString() + currency;
        }

        protected void SetDescriptionText()
        {
            sliderDescriptionText.text = description;
        }
    }
}
