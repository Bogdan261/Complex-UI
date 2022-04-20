using Assets.Scripts.Managers;
using Assets.Scripts.UiElements.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class PopUpScreen : Screen, IPopUp
    {
        public string MessageText;
        
        [SerializeField]
        private Screen imageDisplayPanel;

        [SerializeField]
        private TextMeshProUGUI message;


        private Image instantiatedImage;        

        private void OnEnable()
        {
            DisplayImage();
            SetText();
        }            

        private void OnDisable()
        {
            DestroyImage();
        }

        private void SetText()
        {
            message.text = MessageText;
        }

        private void DisplayImage()
        {
            if (PopUpScreenManager.Instance.ImageToDisplay != null)
            {
                var imageToShow = PopUpScreenManager.Instance.ImageToDisplay;
                instantiatedImage = Instantiate(imageToShow);
                instantiatedImage.transform.SetParent(imageDisplayPanel.transform);
            }
        }

        private void DestroyImage()
        {
            if (instantiatedImage != null)
            {
                Destroy(instantiatedImage.gameObject);
            }
        }
    }
}
