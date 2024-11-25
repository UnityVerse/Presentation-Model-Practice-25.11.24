using System;
using UnityEngine;

public interface IProductPopupPresentation
{
    void Consume();
    event Action OnUpdate;

    string Description { get; }
    string Title { get; }
    string Count { get; }
    Sprite Icon { get; }
    bool CanConsume { get; }
}