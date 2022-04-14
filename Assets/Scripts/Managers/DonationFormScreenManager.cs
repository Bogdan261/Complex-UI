using Assets.Scripts.UiElements.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class DonationFormScreenManager : ScreenManager
    {
        public static DonationFormScreenManager Instance;

        [SerializeField]
        private FixedValueSlider mainValueSlider;

        [SerializeField]
        private BasicSlider charitiesPartSlider;

        [SerializeField]
        private BasicSlider redactionPartSlider;

        [SerializeField]
        private BasicSlider naturePartSlider;

        private float charitiesPartSliderPreviousValue = 100;

        private float redactionPartSliderPreviousValue = 0;

        private float naturePartSliderPreviousValue = 0;


        private void Awake()
        {
            CreateSingletonInstance();            
        }

        private void Start()
        {
            ConfigureSliders();
        }

        private void ConfigureSliders()
        {
            ConfigureSlider(mainValueSlider, minValue: 1, maxValue: 5, currentValue: 1, valueMultiplier: 20);
            ConfigureSlider(charitiesPartSlider, minValue: 0, maxValue: 100, currentValue: 100);
            ConfigureSlider(redactionPartSlider, minValue: 0, maxValue: 100, currentValue: 0);
            ConfigureSlider(naturePartSlider, minValue: 0, maxValue: 100, currentValue: 0);
        }

        private void ConfigureSlider(BasicSlider slider, int minValue, int maxValue, float currentValue, int valueMultiplier = 0)
        {
            slider.SetSliderIntervalValues(minValue, maxValue);
            slider.SetSliderMultiplier(valueMultiplier);
            slider.SetSliderCurrentValue(currentValue);

            var sliderEvent = slider.GetSliderEvent();
            sliderEvent.AddListener(delegate { UpdatePercentageSliderValues(); });
        }

        private void UpdatePercentageSliderValues()
        {
            if(charitiesPartSliderPreviousValue != charitiesPartSlider.GetSliderCurrentValue())
            {
                var difference = charitiesPartSliderPreviousValue - charitiesPartSlider.GetSliderCurrentValue();
                redactionPartSlider.SetSliderCurrentValue(redactionPartSliderPreviousValue + difference / 2.0f);
                naturePartSlider.SetSliderCurrentValue(naturePartSliderPreviousValue + difference / 2.0f);              
            }
            redactionPartSliderPreviousValue = redactionPartSlider.GetSliderCurrentValue();
            naturePartSliderPreviousValue = naturePartSlider.GetSliderCurrentValue();
            charitiesPartSliderPreviousValue = charitiesPartSlider.GetSliderCurrentValue();
        }

        private void CreateSingletonInstance()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
