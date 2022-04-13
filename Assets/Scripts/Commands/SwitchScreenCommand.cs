using Assets.Scripts.Commands.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SwitchScreenCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private UiElements.Screen currentScreen;

        [SerializeField]
        private UiElements.Screen targetScreen;

        public void Execute()
        {
            targetScreen.gameObject.SetActive(true);
            currentScreen.gameObject.SetActive(false);
        }

        public void SetScreens(UiElements.Screen currentScreen, UiElements.Screen targetScreen)
        {
            this.currentScreen = currentScreen;
            this.targetScreen = targetScreen;
        }
    }
}
