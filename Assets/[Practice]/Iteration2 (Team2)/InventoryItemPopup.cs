using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    ///Показывает выбранный предмет
    public sealed class InventoryItemPopup : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private TMP_Text description;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Button useButton;

        [SerializeField]
        private TMP_Text count;
    }
}