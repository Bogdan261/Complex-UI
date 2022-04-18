using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UiElements.Screens
{
    public class ToggleDescriptionItemsScreen : Screen
    {
        [SerializeField]
        private TextMeshProUGUI descriptionTextPrefab;

        private const float defaultFontSize = 35f;

        private List<TextMeshProUGUI> instantiatedDescriptionItems;

        private void Awake()
        {
            instantiatedDescriptionItems = new List<TextMeshProUGUI>();
        }

        public void DisplayDescriptionItem(string description)
        {
            var result = Instantiate(descriptionTextPrefab);
            instantiatedDescriptionItems.Add(result);

            ConfigureDescriptionItem(result, description);
        }

        private void ConfigureDescriptionItem(TextMeshProUGUI descriptionTextItem, string description)
        {
            descriptionTextItem.transform.SetParent(gameObject.transform);
            descriptionTextItem.fontSize = defaultFontSize;
            descriptionTextItem.text = description;
        }
    }
}
