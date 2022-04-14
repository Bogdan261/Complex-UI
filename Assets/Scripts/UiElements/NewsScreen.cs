using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements
{    
    public class NewsScreen : Screen
    {
        [SerializeField]
        private NewsCardsListSO newsList;

        [SerializeField]
        private GameObject newsScrollViewContent; //could be someting else instead of GO

        [SerializeField]
        private Card newsCardPrefab;

        [SerializeField]
        private Screen nextScreen;

        private void Start()
        {
            DisplayNewsCards();
        }

        private void DisplayNewsCards()
        {
            foreach(var newsCard in newsList.CardsList)
            {
                var result = Instantiate(newsCardPrefab);
                result.transform.SetParent(newsScrollViewContent.transform);              
                result.SetTitleText(newsCard.Title);
                result.SetDescriptionText(newsCard.ShortDescription);
                result.ConfigureSwitchScreenCommand(this, nextScreen);
                result.ConfigureImagesListCommand(newsCard.ImagesList);
            }
        }
    }
}
