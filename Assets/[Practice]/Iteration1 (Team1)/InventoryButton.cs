using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    ///Открывает попап инвентаря при нажатии 
    public sealed class InventoryButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        private InventoryPopup popup;
    }
}