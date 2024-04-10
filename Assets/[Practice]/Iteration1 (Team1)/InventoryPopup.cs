using UnityEngine;

namespace SampleGame
{
    ///Отображает список предметов инвентаря в виде сетки на экране
    public sealed class InventoryPopup : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemCard prefab;

        [SerializeField]
        private Transform container;

        private IInventoryPresenter presenter;
    }
}