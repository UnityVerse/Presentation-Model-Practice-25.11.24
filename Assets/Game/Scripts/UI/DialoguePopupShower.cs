using Sirenix.OdinInspector;

namespace Game.Scripts.UI
{
    
    public sealed class DialoguePopupShower
    {
        private readonly DialoguePopup popup;

        public DialoguePopupShower(DialoguePopup popup)
        {
            this.popup = popup;
        }

        [Button]
        public void Show()
        {
            this.popup.Show();
        }
    }
}