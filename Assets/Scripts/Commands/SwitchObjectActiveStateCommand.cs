using Assets.Scripts.Commands.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SwitchObjectActiveStateCommand : ICommand
    {
        private GameObject gameObject;

        public void Execute()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void SetGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
