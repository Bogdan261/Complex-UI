using Assets.Scripts.UiElements.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class ToggleGroupScreen : ToggleGroup, IScreen
    {      
        [SerializeField]
        public CustomToggle togglePrefab;

        private List<CustomToggle> instantiatedToggles;

        private void Start()
        {
            instantiatedToggles = new List<CustomToggle>();

            InstantiateToggle("More to charity", true , new List<string>() { "Text 1 aaa", "Text 2", "Text 33333", "Text 444444" });
            InstantiateToggle("More to myself", false, new List<string>() { "Text 1 aaa", "Text 2", "Text 33333", "Text 444444", "sdSdsdsds" });
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
    }
}
