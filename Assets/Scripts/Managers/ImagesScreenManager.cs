using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class ImagesScreenManager : ScreenManager
    {
        public static ImagesScreenManager Instance;

        [HideInInspector]
        public ImagesListSO ImagesListSO;

        [HideInInspector]
        public Image ImageToDisplay;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
