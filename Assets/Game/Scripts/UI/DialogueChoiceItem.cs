using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class DialogueChoiceItem: MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;

        private IDialoguePopupPresenter.IChoiceItemPresenter presenter;
        
        public void Construct(IDialoguePopupPresenter.IChoiceItemPresenter presenter)
        {
            this.presenter = presenter;
            this.text.text = presenter.Text;
        }

        private void OnEnable() => this.button.onClick.AddListener(OnClick);
        private void OnDisable() => this.button.onClick.RemoveListener(OnClick);

        private void OnClick() => this.presenter.OnClick();
    }
}