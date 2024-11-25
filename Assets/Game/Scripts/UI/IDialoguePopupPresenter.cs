using System;
using Game.GameEngine;
using UnityEngine;

namespace Game.Scripts.UI
{
    public interface IDialoguePopupPresenter
    {
        event Action OnStateChanged;
        event Action OnDialogFinished;

        Sprite CharacterIcon { get; }
        string CurrentText { get; }
        IChoiceItemPresenter[] Choices { get; }

        void ResetDialogue();

        public interface IChoiceItemPresenter
        {
            string Text { get; }
            void OnClick();
        }


    }

    public class DialoguePopupPresenter : IDialoguePopupPresenter
    {
        public class ChoiceItemPresenter : IDialoguePopupPresenter.IChoiceItemPresenter
        {
            private readonly Action _action;

            public ChoiceItemPresenter(string text, Action action)
            {
                Text = text;
                _action = action;
            }

            public string Text { get; }
            public void OnClick()
            {
                _action?.Invoke();
            }
        }
        private IDialoguePopupPresenter.IChoiceItemPresenter[] _choices;
        private readonly Dialogue _dialogue;

        public DialoguePopupPresenter(Dialogue dialogue)
        {
            _dialogue = dialogue;
            CurrentText = dialogue.CurrentMessage;
            InitializeChoices();

        }

        private void InitializeChoices()
        {
            _choices = new IDialoguePopupPresenter.IChoiceItemPresenter[_dialogue.CurrentChoices.Length];
            for (var i = 0; i < _choices.Length; i++)
            {
                var next = i;
                _choices[i] = new ChoiceItemPresenter(_dialogue.CurrentChoices[i], () =>
                {
                    if (!_dialogue.MoveNext(next))
                    {
                        OnDialogFinished?.Invoke();
                        OnStateChanged?.Invoke();
                        return;
                    }

                    CurrentText = _dialogue.CurrentMessage;
                    InitializeChoices();
                    OnStateChanged?.Invoke();
                });
            }
        }

        public event Action OnStateChanged;
        public event Action OnDialogFinished;
        public Sprite CharacterIcon => _dialogue.Icon;
        public string CurrentText { get; private set; }
        public IDialoguePopupPresenter.IChoiceItemPresenter[] Choices => _choices;
        public void ResetDialogue()
        {
            _dialogue.Reset();
            CurrentText = _dialogue.CurrentMessage;

            InitializeChoices();
        }
    }
}