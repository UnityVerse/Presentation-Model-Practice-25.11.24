using Game.GameEngine;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class DialogueDebug: MonoBehaviour
    {
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private Dialogue dialogue;
        
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private DialoguePopupShower popupShower;
    }
}