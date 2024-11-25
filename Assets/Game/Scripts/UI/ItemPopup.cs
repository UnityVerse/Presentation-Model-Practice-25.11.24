using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class ItemPopup : MonoBehaviour
    {
        [SerializeField] private Button _consumeButton;
        
        [SerializeField] private Image _icon;
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private TMP_Text _description;

        private IItemPresenter _itemPresenter;

        [Inject]
        private void Construct(IItemPresenter presenter) 
            => _itemPresenter = presenter;

        [Button]
        public void Show()
        {
            _consumeButton.onClick.AddListener(_itemPresenter.ConsumeClicked);
            _itemPresenter.OnCountChanged += UpdateCount;

            SetInfo();
            
            gameObject.SetActive(true);
        }

        [Button]
        public void Hide()
        {
            _consumeButton.onClick.RemoveListener(_itemPresenter.ConsumeClicked);
            _itemPresenter.OnCountChanged -= UpdateCount;
            
            gameObject.SetActive(false);
        }
        
        private void SetInfo()
        {
            _icon.sprite = _itemPresenter.Icon;
            _title.text = _itemPresenter.Title;
            _description.text = _itemPresenter.Description;
            UpdateCount();
        }
        
        private void UpdateCount() 
            => _count.text = _itemPresenter.Count;
    }
}