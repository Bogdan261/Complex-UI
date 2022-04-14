using Assets.Scripts.Managers;
using Assets.Scripts.UiElements.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.UiElements.Behaviors
{
    public class OpenImagePopUp : OpenPopUp
    {
        public void SetTargetPopUp(PopUpScreen popUpScreen, Image imageToShow)
        {
            base.SetTargetPopUp(popUpScreen);
            ImagesScreenManager.Instance.ImageToDisplay = imageToShow;
        }
    }
}
