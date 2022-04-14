using Assets.Scripts.Managers;
using Assets.Scripts.UiElements.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class PopUpScreen : Screen, IPopUp
    {
        [SerializeField]
        private Screen imageDisplay;

        private Image instantiatedImage;

        private void OnEnable()
        {
            DisplayImage();
        }            

        private void OnDisable()
        {
            DestroyImage();
        }

        private void DisplayImage()
        {
            var imageToShow = ImagesScreenManager.Instance.ImageToDisplay;
            instantiatedImage = Instantiate(imageToShow);
            instantiatedImage.transform.SetParent(imageDisplay.transform);
        }

        private void DestroyImage()
        {
            Destroy(instantiatedImage.gameObject);
        }
    }
}
