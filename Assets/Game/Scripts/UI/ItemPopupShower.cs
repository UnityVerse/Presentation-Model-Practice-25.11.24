using System;
using Modules.Inventories;
using Sirenix.OdinInspector;

namespace SampleGame
{
    public sealed class ItemPopupShower
    {
        private readonly ProductPopupView popup;
        private readonly IItemPresenter presenter;

        public ItemPopupShower(ProductPopupView popup, IItemPresenter presenter)
        {
            this.popup = popup;
            this.presenter = presenter;
        }

        [Button]
        public void Show(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            
            this.presenter.ChangeItem(item);
            this.popup.Show();
        }
    }
}