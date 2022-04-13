using UnityEngine;

[CreateAssetMenu(fileName = "NewNewsCard", menuName = "News/Card")]
public class NewsCardSO : ScriptableObject
{
    public string Title;

    public string ShortDescription;

    public ImagesListSO ImagesList;
}
