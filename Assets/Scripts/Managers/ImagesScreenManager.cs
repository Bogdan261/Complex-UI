using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ImagesScreenManager : ScreenManager
    {
        public static ImagesScreenManager Instance;

        [HideInInspector]
        public ImagesListSO ImagesListSO;

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
