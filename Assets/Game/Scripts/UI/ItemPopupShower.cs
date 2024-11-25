using Modules.Inventories;

namespace SampleGame
{
    using UnityEngine;
    using Zenject;

    public sealed class ItemPopupShower
    {
        [Inject]  ItemPresenterMock _itemPresenterMock;
        
        public void Show(InventoryItem item)
        {
            _itemPresenterMock.Show(item);
        }
    }
}