using System;
using Modules.Inventories;
using UnityEngine;

namespace SampleGame
{
    public class ItemPresenter : IItemPresenter
    {
        private readonly Inventory _inventory;
        private InventoryItem _currentItem;
        public event Action OnCountChanged;
        public Sprite Icon => _currentItem.Icon;
        public string Title => _currentItem.Title;
        public string Count => _inventory.GetCount(_currentItem).ToString();
        public string Description => _currentItem.Decription;

        public ItemPresenter(Inventory inventory)
        {
            _inventory = inventory;
        }
        
        public void ConsumeClicked()
        {
            _inventory.RemoveItem(_currentItem);
        }

        public void Display(InventoryItem item)
        {
            _currentItem = item;
        }
    }
}