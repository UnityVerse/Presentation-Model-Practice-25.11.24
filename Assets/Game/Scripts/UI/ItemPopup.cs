namespace SampleGame
{
    using System;
    using Modules.Inventories;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Serialization;
    using UnityEngine.UI;
    using Zenject;

    public sealed class ItemPopup : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] Button _consumeButton;
        [SerializeField] Button _closeButton;
        
        [SerializeField] Image _icon;
        
        [SerializeField] TextMeshProUGUI _titleText;
        [SerializeField] TextMeshProUGUI _descriptionText;
        [SerializeField] TextMeshProUGUI _countText;
     
        [Inject] IItemPresenter _presenter;
        
        public void Initialize()
        {
            _presenter.OnShow += Show;
            
            _consumeButton.onClick.AddListener( OnButtonClicked );
            _closeButton.onClick.AddListener( Close );
        }

        public void Dispose()
        {
            _presenter.OnShow -= Show;
            
            _consumeButton.onClick.RemoveListener( OnButtonClicked );
            _closeButton.onClick.RemoveListener( Close );
        }

        void Show()
        {
            gameObject.SetActive( true );
            Setup();
        }

        void Close()
        {
            gameObject.SetActive(false);
        }

        void Setup()
        {
            _icon.sprite = _presenter.Icon;
            _titleText.text = _presenter.Title;
            _descriptionText.text = _presenter.Description;
            _countText.text = _presenter.Count;
        }
        
        void OnButtonClicked() => _presenter.TryConsume();
    }
}