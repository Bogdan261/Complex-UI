using Assets.Scripts.Entities;
using Assets.Scripts.Helpers.ExtensionMethods;
using Assets.Scripts.UiElements.Sliders;
using System.Collections.Generic;
using System.Linq;
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

        private readonly List<string> donationCauses = new List<string>()
        {
            "Redaction",
            "Africa",
            "Nature"
        };

        private readonly List<DonationsPackage> donationsPackages = new List<DonationsPackage>()
        {
            new DonationsPackage(
               1,
               "Redaction's bread",
               new List<(string, float)>{("Redaction", 60), ("Africa", 20), ("Nature", 20)}
            ),
            new DonationsPackage(
               2,
               "Africa's water",
               new List<(string, float)>{("Redaction", 30), ("Africa", 60), ("Nature", 10)}
            ),
            new DonationsPackage(
               3,
               "Nature Lovers",
               new List<(string, float)>{("Redaction", 30), ("Africa", 10), ("Nature", 60)}
            ),
        };


        private void Awake()
        {           
            ConfigureMainSlider();           
        }

        private void Start()
        {           
            CreateTogglesForCauses();

            CreatePercentageSlidersForCauses();

            PercentageDivisionSlidersScreen.Instance.gameObject.SetActive(false);
        }

        private void CreatePercentageSlidersForCauses()
        {
            foreach(var cause in donationCauses)
            {
                PercentageDivisionSlidersScreen.Instance.InstantiatePercentageSlider(cause);
            }
        }

        private void CreateTogglesForCauses()
        {
            var isFirstToggle = true;

            foreach (var package in donationsPackages)
            {
                var descriptionItems = CreateDescriptionItems(package.CausePercentages);

                ToggleGroupScreen.Instance.InstantiateToggle(package.Id, package.PackageName, isFirstToggle, descriptionItems);

                isFirstToggle = false;
            }
        }

        private void UpdateTogglesForCausesValues()
        {
            foreach (var package in donationsPackages)
            {
                var descriptionItems = CreateDescriptionItems(package.CausePercentages);

                ToggleGroupScreen.Instance.UpdateToggleDescription(package.Id, descriptionItems);                
            }
        }

        private void ConfigureMainSlider()
        {
            mainValueSlider.SetWholeNumbers();          

            mainValueSlider.ConfigureSlider(minValue: valueSliderMinValue, maxValue: valueSliderMaxValue, currentValue: 1, valueMultiplier: sliderValueMultiplier);
            
            var mainValueSliderEvent = mainValueSlider.GetSliderEvent();
            mainValueSliderEvent.AddListener(delegate { UpdateTogglesForCausesValues(); });
        }
        
        private List<string> CreateDescriptionItems(List<(string,float)> causePercentages)
        {
            var descriptionItems = new List<string>();

            foreach (var causeSeparation in causePercentages)
            {
                descriptionItems.Add(causeSeparation.Item1 + ": " + (mainValueSlider.GetTotalAmount() * causeSeparation.Item2 / 100).ToString());
            }

            return descriptionItems;
        }
    }
}
