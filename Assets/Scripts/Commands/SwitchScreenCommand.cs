using Assets.Scripts.Commands.Interfaces;
using Assets.Scripts.UiElements.Screens;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SwitchScreenCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private UiElements.Screens.Screen currentScreen;

        [SerializeField]
        private UiElements.Screens.Screen targetScreen;

        public virtual void Execute()
        {
            targetScreen?.gameObject.SetActive(true);
            currentScreen?.gameObject.SetActive(false);
        }

        public void SetScreens(UiElements.Screens.Screen currentScreen, UiElements.Screens.Screen targetScreen)
        {
            this.currentScreen = currentScreen;
            this.targetScreen = targetScreen;
        }
    }
}
