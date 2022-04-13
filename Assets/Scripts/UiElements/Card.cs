using Assets.Scripts.Helpers.ExtensionMethods;
using Assets.Scripts.UiElements.Interfaces;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements
{
    public class Card : MonoBehaviour, ICard
    {
        private TextMeshProUGUI titleText;

        private TextMeshProUGUI descriptionText;

        private Button openButton;

        private const string titleTag = "Title";

        private const string descriptionTag = "Description";

        private void Awake()
        {
            SetTextElements();
            SetOpenButton();
        }      

        public void SetDescriptionText(string text)
        {
            if (descriptionText != null)
            {
                descriptionText.text = text;
            }
        }

        public void SetTitleText(string text)
        {          
            if (titleText != null)
            {
                titleText.text = text;
            }
        }

        public void SetSwitchScreenCommand(Screen currentScreen, Screen targetScreen)
        {
            var buttonCommand = openButton.GetSwitchScreenCommand();
            buttonCommand?.SetScreens(currentScreen, targetScreen);
        }

        public void SetTextElements()
        {
            var textComponents = GetComponentsInChildren<TextMeshProUGUI>();

            titleText = textComponents?.Where(x => x.gameObject.CompareTag(titleTag)).FirstOrDefault();
            descriptionText = textComponents?.Where(x => x.gameObject.CompareTag(descriptionTag)).FirstOrDefault();
        }

        private void SetOpenButton()
        {
            openButton = GetComponentInChildren<Button>();
        }
    }
}
