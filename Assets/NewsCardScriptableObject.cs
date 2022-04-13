using UnityEngine;

[CreateAssetMenu(fileName = "NewNewsCard", menuName = "News/Card")]
public class NewsCardScriptableObject : ScriptableObject
{
    public string Title;

    public string ShortDescription;
}
