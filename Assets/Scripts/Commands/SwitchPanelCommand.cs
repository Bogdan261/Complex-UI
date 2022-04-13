using Assets.Scripts.Commands.Interfaces;
using Assets.Scripts.Panels;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SwitchPanelCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private Panel currentPanel;

        [SerializeField]
        private Panel nextPanel;

        public void Execute()
        {
            nextPanel.gameObject.SetActive(true);
            currentPanel.gameObject.SetActive(false);
        }
    }
}
