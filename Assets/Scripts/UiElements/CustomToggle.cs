using Assets.Scripts.Helpers;
using Assets.Scripts.UiElements.Interfaces;
using Assets.Scripts.UiElements.Screens;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements
{
    public class CustomToggle : Toggle, ICustomToggle
    {
        public int Id;

        public string Name;

        public List<string> DescriptionItemsText;          
       
        public ToggleDescriptionItemsScreen toggleDescriptionItemsScreen;

        private const float textSize = 35f;
        private TextMeshProUGUI titleLabelText;

        private void Awake()
        {
            toggleDescriptionItemsScreen = GetComponentInChildren<ToggleDescriptionItemsScreen>();
            titleLabelText = GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault(x => x.gameObject.CompareTag(ProjectTags.Title));

            SetToggleTextSize();           
            SetDescriptionItems(DescriptionItemsText);
        }

        public void SetToggleId(int id)
        {
            Id = id;
        }

        public void SetToggleName(string name)
        {
            titleLabelText.text = name;
        }

        public void SetToggleOnOff(bool value)
        {
            isOn = value;
        }

        public void SetToggleGroup(ToggleGroup toggleGroup)
        {
            this.group = toggleGroup;
        }

        public void SetDescriptionItems(List<string> descriptionItemsText)
        {
            toggleDescriptionItemsScreen.ClearPreviousDescriptionItems();

            foreach (var text in descriptionItemsText)
            {
                toggleDescriptionItemsScreen.DisplayDescriptionItem(text);
            }
        }      

        private void SetToggleTextSize()
        {
            titleLabelText.fontSize = textSize;
        }
    }
}
