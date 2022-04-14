using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;

namespace Assets.Scripts.UiElements.Sliders
{
    public class BasicSlider : MonoBehaviour
    {
        protected Slider slider;
        protected TextMeshProUGUI sliderValueText;

        protected float sliderValueMultiplier;

        protected const string currency = "$";

        protected virtual void Awake()
        {
            slider = GetComponent<Slider>();
            sliderValueText = GetComponentInChildren<TextMeshProUGUI>();
            SetValueText();
            slider.onValueChanged.AddListener(delegate { SetValueText(); });
        }

        public float GetSliderAmount()
        {
            return slider.value * sliderValueMultiplier;
        }

        public SliderEvent GetSliderEvent()
        {
            return slider.onValueChanged;
        }

        public void SetSliderIntervalValues(float minValue, float maxValue)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
        }

        public void SetSliderCurrentValue(float value)
        {
            slider.value = value;
        }

        public float GetSliderCurrentValue()
        {
            return slider.value;
        }

        public void SetSliderMultiplier(float sliderValueMultiplier)
        {
            this.sliderValueMultiplier = sliderValueMultiplier;
        }
      
        protected void SetValueText()
        {
            sliderValueText.text = GetSliderAmount().ToString() + currency;
        }
      
    }
}
