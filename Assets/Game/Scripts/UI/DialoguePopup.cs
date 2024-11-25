using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public class DialoguePopup: MonoBehaviour
    {
        [SerializeField] private Image characterIcon;
        [SerializeField] private TMP_Text bubbleText;
        [SerializeField] private DialogueChoiceListView choiceListView;
        
        private IDialoguePopupPresenter presenter;

        [Inject]
        public void Construct(IDialoguePopupPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void Show()
        {
            presenter.OnStateChanged += UpdateState;
            presenter.OnDialogFinished += Hide;
            gameObject.SetActive(true);
            presenter.ResetDialogue();
            UpdateState();
        }

        public void Hide()
        {
            presenter.OnStateChanged -= UpdateState;
            presenter.OnDialogFinished -= Hide;
            gameObject.SetActive(false);
        }

        public void UpdateState()
        {
            characterIcon.sprite = presenter.CharacterIcon;
            bubbleText.text = presenter.CurrentText;

            UpdateChoiceList();
        }

        private void UpdateChoiceList()
        {
            choiceListView.Clear();
            foreach (var choice in presenter.Choices)
            {
                var item = choiceListView.SpawnItem();
                item.Construct(choice);
            }
        }
    }
}