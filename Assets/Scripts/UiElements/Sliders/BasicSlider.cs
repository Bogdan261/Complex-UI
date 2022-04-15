using Assets.Scripts.Helpers;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;

namespace Assets.Scripts.UiElements.Sliders
{
    [RequireComponent(typeof(Slider))]
    public class BasicSlider : MonoBehaviour
    {
        [SerializeField]
        protected string description;
        
        protected Slider slider;

        protected TextMeshProUGUI sliderValueText;

        protected TextMeshProUGUI sliderDescriptionText;

        protected float sliderValueMultiplier;

        protected const string currency = "$";

        protected virtual void Awake()
        {
            slider = GetComponent<Slider>();
            sliderValueText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Value));
            sliderDescriptionText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Description));

            SetValueText();
            SetDescriptionText();

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

        public void RefreshValueText()
        {
            SetValueText();
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
