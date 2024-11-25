using System;
using UnityEngine;

public class ProductPopupPresentationMock : IProductPopupPresentation
{

    private int _count = 10;
    public void Consume()
    {

        Debug.Log("Consume");
        _count--;

        OnUpdate?.Invoke();
    }

    public event Action OnUpdate;
    public string Description { get; } = "Test descr";
    public string Title { get; } = "Test title";
    public string Count => _count.ToString();
    public bool CanConsume => _count > 0;
    public Sprite Icon { get; } = Resources.Load<Sprite>("icon");
}