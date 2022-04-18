using Assets.Scripts.UiElements.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class ToggleGroupScreen : ToggleGroup, IScreen
    {
        [HideInInspector]
        public static ToggleGroupScreen Instance;

        [SerializeField]
        private CustomToggle togglePrefab;

        private List<CustomToggle> instantiatedToggles;

        private void Awake()
        {
            DefineSingleton();
            instantiatedToggles = new List<CustomToggle>();
        }     

        public void InstantiateToggle(string toggleName, bool isOn, List<string> descriptionItemsText)
        {
            var result = Instantiate(togglePrefab);           
            instantiatedToggles.Add(result);
            result.transform.SetParent(transform);

            result.SetToggleName(toggleName);
            result.SetToggleOnOff(isOn);
            result.SetToggleGroup(this);

            result.SetDescriptionItems(descriptionItemsText);           
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
