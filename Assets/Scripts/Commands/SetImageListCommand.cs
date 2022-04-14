using Assets.Scripts.Commands.Interfaces;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SetImageListCommand : MonoBehaviour, ICommand
    {
        private ImagesListSO imagesList;

        public void Execute()
        {
            ImagesScreenManager.Instance.ImagesListSO = imagesList;
        }

        public void SetImagesList(ImagesListSO imagesList)
        {
            this.imagesList = imagesList;
        }
    }
}
