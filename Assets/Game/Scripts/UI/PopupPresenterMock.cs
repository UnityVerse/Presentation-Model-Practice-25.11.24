using System;
using Modules.Inventories;
using UnityEngine;

namespace SampleGame
{
    public class PopupPresenterMock : IItemPresenter
    {
        private int _count = 10;
        
        public event Action OnCountChanged;
        public Sprite Icon => Resources.Load<Sprite>("Arcane Stone");
        public string Title => Icon.name;
        public string Count => $"{_count}";
        public string Description => "Безделушка, но стоит дорого";
        
        public void ConsumeClicked()
        {
            Debug.Log("Consume Clicked");
            _count--;
            OnCountChanged?.Invoke();
        }

        public void Display(InventoryItem item)
        {
            throw new NotImplementedException();
        }
    }
}