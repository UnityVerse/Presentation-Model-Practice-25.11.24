namespace SampleGame
{
    using System;
    using Modules.Inventories;
    using UnityEngine;

    public interface IItemPresenter
    {
        event Action OnShow;
        
        Sprite Icon { get; }
        string Title { get;}
        string Description { get; }
        string Count { get;}
        
        void TryConsume();
    }
}