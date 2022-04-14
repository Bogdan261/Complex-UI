using Assets.Scripts.Managers;
using Assets.Scripts.UiElements.Behaviors;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
{
    public class ImagesScreen : Screen
    {
        [SerializeField]
        private Screen imagesPanel;

        [SerializeField]
        private PopUpScreen imagePopUp;

        private List<Image> instantiatedImages;

        private void Awake()
        {
            instantiatedImages = new List<Image>();
        }

        private void OnEnable()
        {
            DisplayImages();
        }

        private void OnDisable()
        {
            DestroyImages();
        }

        private void DisplayImages()
        {
            foreach (var image in ImagesScreenManager.Instance.ImagesListSO.ImagesList)
            {
                var result = Instantiate(image);
                instantiatedImages.Add(result);
                result.transform.SetParent(imagesPanel.transform);
                ConfigureImagePopUp(result);
            }
        }

        private void ConfigureImagePopUp(Image image)
        {
            var openPopUpComponent = image.gameObject.AddComponent<OpenImagePopUp>();
            openPopUpComponent.SetTargetPopUp(imagePopUp, image);
        }

        private void DestroyImages()
        {
            foreach (var image in instantiatedImages)
            {
                Destroy(image.gameObject);
            }

            instantiatedImages = new List<Image>();
        }
    }
}
