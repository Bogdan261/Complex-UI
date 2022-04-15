using Assets.Scripts.Helpers;
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

        public void ConfigureSwitchScreenCommand(UiElements.Screens.Screen currentScreen, UiElements.Screens.Screen targetScreen)
        {
            var buttonCommand = openButton.GetSwitchScreenCommand();
            buttonCommand?.SetScreens(currentScreen, targetScreen);
        }

        public void ConfigureImagesListCommand(ImagesListSO imagesList)
        {
            var buttonCommand = openButton.GetImageListCommand();
            buttonCommand?.SetImagesList(imagesList);
        }

        private void SetTextElements()
        {
            var textComponents = GetComponentsInChildren<TextMeshProUGUI>();

            titleText = textComponents?.Where(x => x.gameObject.CompareTag(ProjectTags.Title)).FirstOrDefault();
            descriptionText = textComponents?.Where(x => x.gameObject.CompareTag(ProjectTags.Description)).FirstOrDefault();
        }

        private void SetOpenButton()
        {
            openButton = GetComponentInChildren<Button>();
        }
    }
}
