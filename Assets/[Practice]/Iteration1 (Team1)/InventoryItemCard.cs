using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    ///Отображает предмет инвентаря в виде карточки группы
    public sealed class InventoryItemCard : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text count;

        private IInventoryItemPresenter presenter;
    }
}