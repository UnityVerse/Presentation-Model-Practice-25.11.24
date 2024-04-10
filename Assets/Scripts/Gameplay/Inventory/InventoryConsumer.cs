using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    //Нельзя менять!
    internal sealed class InventoryConsumer : IInventoryConsumer
    {
        public event Action<InventoryItem> OnItemConsumed;

        private readonly Inventory inventory;

        public InventoryConsumer(Inventory inventory)
        {
            this.inventory = inventory;
        }

        [Button]
        public bool CanConsume(InventoryItem item)
        {
            return item.IsConsumable && this.inventory.HasItem(item);
        }

        [Button]
        public void Consume(InventoryItem item)
        {
            if (!this.CanConsume(item))
            {
                throw new Exception($"Can not consume item {item.name}!");
            }

            this.inventory.RemoveItem(item);
            Debug.Log($"<color=green>{item.Title}</color> activated!");
            this.OnItemConsumed?.Invoke(item);
        }
    }
}