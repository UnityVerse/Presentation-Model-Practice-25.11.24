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
    private IProductPopupPresentation _presentation;

    [Inject]
    public void Construct(IProductPopupPresentation presentation)
    {
        _presentation = presentation;
    }

    private void HandleUpdateView()
    {
        if (_presentation == null)
            return;

        _title.text = _presentation.Title;
        _description.text = _presentation.Description;
        _count.text = _presentation.Count;
        _icon.sprite = _presentation.Icon;
        _consumeButton.interactable = _presentation.CanConsume;
    }

    private void Awake()
    {
        _consumeButton.onClick.AddListener(HandleConsumeButtonClick);
    }

    private void OnEnable()
    {
        _presentation.OnUpdate += HandleUpdateView;
        HandleUpdateView();
    }

    private void OnDisable()
    {
        _presentation.OnUpdate += HandleUpdateView;
    }


    private void HandleConsumeButtonClick()
    {
        _presentation.Consume();
    }
}