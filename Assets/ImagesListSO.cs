using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Images List", menuName = "News/ImageList")]
public class ImagesListSO : ScriptableObject
{
    public List<Image> ImagesList;
}
