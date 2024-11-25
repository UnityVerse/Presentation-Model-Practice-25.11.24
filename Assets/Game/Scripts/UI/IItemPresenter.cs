using System;
using Modules.Inventories;
using UnityEngine;

namespace SampleGame
{
    public interface IItemPresenter
    {
        public event Action OnCountChanged;
        
        public Sprite Icon { get; }
        public string Title { get; }
        public string Count { get; }
        public string Description { get; }
        
        public void ConsumeClicked();
        
        void Display(InventoryItem item);
    }
}