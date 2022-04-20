using Assets.Scripts.UiElements.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class ToggleGroupScreen : ToggleGroup, IScreen
    {
        [HideInInspector]
        public static ToggleGroupScreen Instance;
        
        private List<CustomToggle> InstantiatedToggles;

        [SerializeField]
        private CustomToggle togglePrefab;        

        private void Awake()
        {
            DefineSingleton();
            InstantiatedToggles = new List<CustomToggle>();
        }     

        public void InstantiateToggle(int id, string toggleName, bool isOn, List<string> descriptionItemsText)
        {
            var result = Instantiate(togglePrefab);           
            InstantiatedToggles.Add(result);
            result.transform.SetParent(transform);

            result.SetToggleId(id);
            result.SetToggleName(toggleName);
            result.SetToggleOnOff(isOn);
            result.SetToggleGroup(this);

            result.SetDescriptionItems(descriptionItemsText);           
        }

        public void UpdateToggleDescription(int id, List<string> descriptionItemsText)
        {
            var toggle = InstantiatedToggles.FirstOrDefault(x => x.Id == id);

            toggle.SetDescriptionItems(descriptionItemsText);
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
