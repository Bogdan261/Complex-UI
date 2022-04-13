using Assets.Scripts.UiElements.Interfaces;
using System;
using System.Collections.Generic;
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

        private void Start()
        {
            SetTextElements();
            SetOpenButton();
        }      

        public void SetDescriptionText(string text)
        {
            descriptionText.text = text;
        }

        public void SetTitleText(string text)
        {
            titleText.text = text;
        }

        private void SetTextElements()
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
