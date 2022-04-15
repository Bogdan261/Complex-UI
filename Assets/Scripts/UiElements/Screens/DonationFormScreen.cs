using Assets.Scripts.UiElements.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UiElements.Screens
{
    public class DonationFormScreen : Screen
    {       
        [SerializeField]
        private FixedValueSlider mainValueSlider;

        [SerializeField]
        private List<BasicSlider> percentageSliders;

        private Dictionary<BasicSlider, float> slidersPreviousValue;

        private const float valueSliderMinValue = 1;
        private const float valueSliderMaxValue = 5;
        private const float sliderValueMultiplier = 40;

        private const float percentageSlidersMinValue = 0;
        private const float percentageSlidersMaxValue = 100;
        private float percentageSlidersValueMultiplier;

        private bool isUpdating;

        private void Start()
        {
            isUpdating = false;       

            slidersPreviousValue = new Dictionary<BasicSlider, float>();
            ConfigureMainSlider();
            ConfigurePercentageSliders();
        }     

        private void ConfigureMainSlider()
        {
            ConfigureSlider(mainValueSlider, minValue: valueSliderMinValue, maxValue: valueSliderMaxValue, currentValue: 1, valueMultiplier: sliderValueMultiplier);
            var sliderEvent = mainValueSlider.GetSliderEvent();
            sliderEvent.AddListener(delegate { UpdatePercentageSlidersMultiplier(); });
        }       

        private void ConfigurePercentageSliders()
        {
            percentageSlidersValueMultiplier = sliderValueMultiplier * mainValueSlider.GetSliderCurrentValue() / percentageSlidersMaxValue;

            for (int i = 0; i < percentageSliders.Count; i++)
            {
                if (i == 0)
                {
                    ConfigurePercentageSlider(percentageSliders[i], minValue: percentageSlidersMinValue, maxValue: percentageSlidersMaxValue, 
                        currentValue: percentageSlidersMaxValue, valueMultiplier: percentageSlidersValueMultiplier);

                    slidersPreviousValue.Add(percentageSliders[i], percentageSlidersMaxValue);
                }
                else
                {
                    ConfigurePercentageSlider(percentageSliders[i], minValue: percentageSlidersMinValue, maxValue: percentageSlidersMaxValue, 
                        currentValue: percentageSlidersMinValue, valueMultiplier: 0);

                    slidersPreviousValue.Add(percentageSliders[i], percentageSlidersMinValue);
                }
            }
        }
        private void ConfigureSlider(BasicSlider slider, float minValue, float maxValue, float currentValue, float valueMultiplier)
        {
            slider.SetSliderIntervalValues(minValue, maxValue);
            slider.SetSliderMultiplier(valueMultiplier);
            slider.SetSliderCurrentValue(currentValue);
        }

        private void ConfigurePercentageSlider(BasicSlider slider, float minValue, float maxValue, float currentValue, float valueMultiplier = 0)
        {
            ConfigureSlider(slider, minValue, maxValue, currentValue, valueMultiplier);

            var sliderEvent = slider.GetSliderEvent();
            sliderEvent.AddListener(delegate { UpdatePercentageSlidersValues(); });
        }

        private void UpdatePercentageSlidersMultiplier()
        {
            percentageSlidersValueMultiplier = sliderValueMultiplier * mainValueSlider.GetSliderCurrentValue() / percentageSlidersMaxValue;

            foreach (var percentageSlider in percentageSliders)
            {
                percentageSlider.SetSliderMultiplier(percentageSlidersValueMultiplier);
                percentageSlider.RefreshValueText();
            }
        }

        private void UpdatePercentageSlidersValues()
        {
            if (!isUpdating)
            {
                foreach (var percentageSlider in percentageSliders)
                {
                    var sliderPreviousValue = slidersPreviousValue[percentageSlider];

                    bool sliderValueChanged = sliderPreviousValue != percentageSlider.GetSliderCurrentValue();

                    if (sliderValueChanged)
                    {
                        isUpdating = true; 
                        var currentSliderValue = percentageSlider.GetSliderCurrentValue();
                        slidersPreviousValue[percentageSlider] = currentSliderValue;
                        percentageSlider.SetSliderMultiplier(percentageSlidersValueMultiplier);
                        percentageSlider.RefreshValueText();

                        UpdateOtherSliders(percentageSlider, sliderPreviousValue);

                        isUpdating = false;
                    }
                }
            }
        } 
        
        private void UpdateOtherSliders(BasicSlider currentSlider, float sliderPreviousValue)
        {
            var numberOfSlidersToDivide = percentageSliders.Count() - 1;

            var differenceToAdd = (sliderPreviousValue - currentSlider.GetSliderCurrentValue()) / numberOfSlidersToDivide;


            //we need to start from the lowest value sliders. When they are decreasing and reach value = 0,
                 // the remaining "to decrease" value needs to be splitted evenly across the following sliders
            percentageSliders = percentageSliders.OrderBy(x => x.GetSliderCurrentValue()).ToList();

            var currentPosition = 0;

            foreach (var percentageSlider in percentageSliders)
                if (percentageSlider != currentSlider)
                {
                    var newValue = slidersPreviousValue[percentageSlider] + differenceToAdd;

                    if (newValue < 0)
                    {
                        var amountForFollowingSliders = newValue / (numberOfSlidersToDivide - currentPosition - 1);

                        differenceToAdd += amountForFollowingSliders;
                        newValue = 0;
                    }
                    else 
                    if (newValue < 0.001f) //to avoid rounding leftovers
                    {
                        newValue = 0;
                    }

                    currentPosition++;

                    slidersPreviousValue[percentageSlider] = newValue;
                    percentageSlider.SetSliderMultiplier(percentageSlidersValueMultiplier);
                    percentageSlider.SetSliderCurrentValue(newValue);                    
                }
        }       
    }
}
