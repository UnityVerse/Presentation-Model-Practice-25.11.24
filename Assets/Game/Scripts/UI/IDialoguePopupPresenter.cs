using System;
using UnityEngine;

namespace Game.Scripts.UI
{
    public interface IDialoguePopupPresenter
    {
        event Action OnStateChanged;
        event Action OnDialogFinished;
        
        Sprite CharacterIcon { get; }
        string CurrentText { get; }
        DialoguePopupPresenter.ChoicePresenter[] Choices { get; }
        
        public interface IChoiceItemPresenter
        {
            string Text { get; }
            void OnClick();
        }
    }
}