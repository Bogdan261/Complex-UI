using Assets.Scripts.Helpers.ExtensionMethods;
using Assets.Scripts.UiElements.Sliders;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UiElements.Screens
{
    public class PercentageDivisionSlidersScreen : Screen
    {              
        [HideInInspector]
        public static PercentageDivisionSlidersScreen Instance;

        [SerializeField]
        private CustomSlider mainValueSlider;

        [SerializeField]
        private CustomSlider percentageSliderPrefab;

        private Dictionary<CustomSlider, float> slidersPreviousValue;

        private List<CustomSlider> instantiatedPercentageSliders;

        private const float percentageSlidersMinValue = 0;
        private const float percentageSlidersMaxValue = 100;
        private float percentageSlidersValueMultiplier;

        private bool isUpdating;

        private void Awake()
        {
            instantiatedPercentageSliders = new List<CustomSlider>();
            slidersPreviousValue = new Dictionary<CustomSlider, float>();

            DefineSingleton();
        }

        public void NoNameIdeea()
        {
            isUpdating = false;            

            AddMainSliderListener();

            ConfigurePercentageSliders();
        } 
        
        public void InstantiatePercentageSlider(string cause)
        {
            var result = Instantiate(percentageSliderPrefab);
            result.transform.SetParent(gameObject.transform);
            instantiatedPercentageSliders.Add(result);
            result.SetDescriptionText(cause);
        }

        private void AddMainSliderListener()
        {
            var mainValueSliderEvent = mainValueSlider.GetSliderEvent();
            mainValueSliderEvent.AddListener(delegate { UpdatePercentageSlidersMultiplier(); });
        }
    
        private void ConfigurePercentageSliders()
        {
            percentageSlidersValueMultiplier =  mainValueSlider.GetTotalAmount() / percentageSlidersMaxValue;

            for (int i = 0; i < instantiatedPercentageSliders.Count; i++)
            {
                if (i == 0)
                {
                    ConfigurePercentageSlider(instantiatedPercentageSliders[i], minValue: percentageSlidersMinValue, maxValue: percentageSlidersMaxValue, 
                        currentValue: percentageSlidersMaxValue, valueMultiplier: percentageSlidersValueMultiplier);

                    slidersPreviousValue.Add(instantiatedPercentageSliders[i], percentageSlidersMaxValue);
                }
                else
                {
                    ConfigurePercentageSlider(instantiatedPercentageSliders[i], minValue: percentageSlidersMinValue, maxValue: percentageSlidersMaxValue, 
                        currentValue: percentageSlidersMinValue, valueMultiplier: 0);

                    slidersPreviousValue.Add(instantiatedPercentageSliders[i], percentageSlidersMinValue);
                }
            }
        }

        private void ConfigurePercentageSlider(CustomSlider slider, float minValue, float maxValue, float currentValue, float valueMultiplier = 0)
        {
            slider.ConfigureSlider(minValue, maxValue, currentValue, valueMultiplier);

            var sliderEvent = slider.GetSliderEvent();
            sliderEvent.AddListener(delegate { UpdatePercentageSlidersValues(); });
        }

        private void UpdatePercentageSlidersMultiplier()
        {
            percentageSlidersValueMultiplier = mainValueSlider.GetTotalAmount() / percentageSlidersMaxValue;

            foreach (var percentageSlider in instantiatedPercentageSliders)
            {
                percentageSlider.SetValueMultiplier(percentageSlidersValueMultiplier);
                percentageSlider.RefreshValueText();
            }
        }

        private void UpdatePercentageSlidersValues()
        {
            if (!isUpdating)
            {
                foreach (var percentageSlider in instantiatedPercentageSliders)
                {
                    var sliderPreviousValue = slidersPreviousValue[percentageSlider];

                    bool sliderValueChanged = sliderPreviousValue != percentageSlider.GetCurrentValue();

                    if (sliderValueChanged)
                    {
                        isUpdating = true; 
                        var currentSliderValue = percentageSlider.GetCurrentValue();
                        slidersPreviousValue[percentageSlider] = currentSliderValue;
                        percentageSlider.SetValueMultiplier(percentageSlidersValueMultiplier);
                        percentageSlider.RefreshValueText();

                        UpdateOtherSliders(percentageSlider, sliderPreviousValue);

                        isUpdating = false;
                    }
                }
            }
        } 
        
        private void UpdateOtherSliders(CustomSlider currentSlider, float sliderPreviousValue)
        {
            var numberOfSlidersToDivide = instantiatedPercentageSliders.Count() - 1;

            var differenceToAdd = (sliderPreviousValue - currentSlider.GetCurrentValue()) / numberOfSlidersToDivide;


            //we need to start from the lowest value sliders. When they are decreasing and reach value = 0,
                 // the remaining "to decrease" value needs to be splitted evenly across the following sliders
            instantiatedPercentageSliders = instantiatedPercentageSliders.OrderBy(x => x.GetCurrentValue()).ToList();

            var currentPosition = 0;

            foreach (var percentageSlider in instantiatedPercentageSliders)
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
                    percentageSlider.SetValueMultiplier(percentageSlidersValueMultiplier);
                    percentageSlider.SetCurrentValue(newValue);                    
                }
        }
        
        private void DefineSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance.gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
