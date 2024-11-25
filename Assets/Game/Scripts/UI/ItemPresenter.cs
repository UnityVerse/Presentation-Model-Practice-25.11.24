using System;
using Modules.Inventories;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public class ItemPresenter : IItemPresenter
    {
        public event Action OnUpdate;

        public string Title => this.item?.Title ?? string.Empty;
        public string Description => this.item?.Decription ?? string.Empty;
        public string Count => (cell?.Count ?? 0).ToString();
        public Sprite Icon => this.item?.Icon;
        public bool CanConsume => (this.item?.IsConsumable ?? false) && inventory.HasItem(item);

        private readonly Inventory inventory;
        private readonly InventoryItemConsumer itemConsumer;

        private InventoryItem item;
        private Inventory.Cell cell;

        public ItemPresenter(Inventory inventory, InventoryItemConsumer itemConsumer, InventoryItem item = default)
        {
            this.inventory = inventory;
            this.itemConsumer = itemConsumer;

            this.ChangeItem(item);
        }
        
        public void Consume()
        {
            itemConsumer.Consume(item);
        }
        
        public void ChangeItem(InventoryItem item)
        {
            if (this.item == item)
            {
                return;
            }

            if (this.cell != null)
            {
                this.cell.OnCountChanged -= OnCountChanged;
            }
            
            this.item = item;
            this.cell = inventory.GetCell(item);
            
            this.cell.OnCountChanged += OnCountChanged;
            
            OnUpdate?.Invoke();
        }

        private void OnCountChanged(int count) => OnUpdate?.Invoke();
    }
}