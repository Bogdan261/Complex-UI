using Assets.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements
{
    public class ImagesScreen : Screen
    {
        [SerializeField]
        private Screen imagesPanel;

        private List<Image> instantiatedImages;

        private void Awake()
        {
            instantiatedImages = new List<Image>();
        }

        private void OnEnable()
        {
            foreach(var image in ImagesScreenManager.Instance.ImagesListSO.ImagesList)
            {
                var result = Instantiate(image);
                instantiatedImages.Add(result);
                result.transform.SetParent(imagesPanel.transform);
            }
        }

        private void OnDisable()
        {
            foreach (var image in instantiatedImages)
            {
                Destroy(image.gameObject);
            }
            instantiatedImages = new List<Image>();
        }
    }
}
