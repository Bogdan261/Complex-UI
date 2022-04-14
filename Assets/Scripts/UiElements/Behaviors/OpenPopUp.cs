using Assets.Scripts.Commands;
using Assets.Scripts.UiElements.Screens;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UiElements.Behaviors
{
    public class OpenPopUp : MonoBehaviour, IPointerDownHandler
    {
        private SwitchScreenCommand switchScreenCommand;

        private void Awake()
        {
            switchScreenCommand = gameObject.AddComponent<SwitchScreenCommand>();
        }

        public void SetTargetPopUp(PopUpScreen popUpScreen)
        {
            switchScreenCommand.SetScreens(null, popUpScreen);
        }      

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            switchScreenCommand.Execute();
        }
    }
}
