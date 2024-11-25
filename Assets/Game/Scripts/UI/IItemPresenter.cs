using System;
using Modules.Inventories;
using UnityEngine;

public interface IItemPresenter
{
    void Consume();
    event Action OnUpdate;

    string Description { get; }
    string Title { get; }
    string Count { get; }
    Sprite Icon { get; }
    bool CanConsume { get; }
    
    // Added
    void ChangeItem(InventoryItem item);
}