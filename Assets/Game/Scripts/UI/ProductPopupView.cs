using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProductPopupView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _consumeButton;
    [SerializeField] private Button _closeButton;
    
    private IItemPresenter _presenter;

    [Inject]
    public void Construct(IItemPresenter presentation)
    {
        _presenter = presentation;
    }

    private void HandleUpdateView()
    {
        if (_presenter == null)
            return;

        _title.text = _presenter.Title;
        _description.text = _presenter.Description;
        _count.text = _presenter.Count;
        _icon.sprite = _presenter.Icon;
        _consumeButton.interactable = _presenter.CanConsume;
    }
    
    public void Show()
    {
        _consumeButton.onClick.AddListener(_presenter.Consume);
        _closeButton.onClick.AddListener(Hide);
        _presenter.OnUpdate += HandleUpdateView;
        HandleUpdateView();
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        _closeButton.onClick.RemoveListener(Hide);
        _consumeButton.onClick.RemoveListener(_presenter.Consume);
        _presenter.OnUpdate -= HandleUpdateView;
        gameObject.SetActive(false);
    }
}