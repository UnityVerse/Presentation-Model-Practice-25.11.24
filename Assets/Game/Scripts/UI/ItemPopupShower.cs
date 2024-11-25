using System;
using Modules.Inventories;

namespace SampleGame
{
    public sealed class ItemPopupShower
    {
        private readonly IItemPresenter _presenter;

        public ItemPopupShower(IItemPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void Show(InventoryItem item)
        {
            _presenter.Display(item);
        }
        
        
    }
}