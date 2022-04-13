using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNewsCardsList", menuName = "News/CardsList")]
public class NewsCardsListSO : ScriptableObject
{
    public List<NewsCardSO> CardsList;
}
