using Assets.Scripts.Commands;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers.ExtensionMethods
{
    public static class ButtonExtensions
    {
        public static SwitchScreenCommand GetSwitchScreenCommand(this Button button)
        {
           var buttonGo = button.gameObject;
           return buttonGo.GetComponent<SwitchScreenCommand>();
        }
    }
}
