using Assets.Scripts.Commands.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SwitchScreenCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private Screens.Screen currentScreen;

        [SerializeField]
        private Screens.Screen targetScreen;

        public void Execute()
        {
            targetScreen.gameObject.SetActive(true);
            currentScreen.gameObject.SetActive(false);
        }
    }
}
