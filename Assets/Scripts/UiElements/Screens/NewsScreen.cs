using Assets.Scripts.UiElements.Behaviors;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Screens
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

        private List<Card> instantiatedCards;

        private void OnEnable()
        {
            instantiatedCards = new List<Card>();

            DisplayNewsCards();
        }

        private void OnDisable()
        {
            DestroyNewsCards();
        }

        private void DisplayNewsCards()
        {
            foreach(var newsCard in newsList.CardsList)
            {
                var result = Instantiate(newsCardPrefab);
                instantiatedCards.Add(result);

                result.transform.SetParent(newsScrollViewContent.transform);              
                result.SetTitleText(newsCard.Title);
                result.SetDescriptionText(newsCard.ShortDescription);
                result.ConfigureSwitchScreenCommand(this, nextScreen);
                result.ConfigureImagesListCommand(newsCard.ImagesList);               
            }
        }

        private void DestroyNewsCards()
        {
            foreach (var newsCard in instantiatedCards)
            {
                Destroy(newsCard.gameObject);
            }

            instantiatedCards = new List<Card>();
        }
    }
}
