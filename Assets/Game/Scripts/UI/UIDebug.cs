using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public class UIDebug: MonoBehaviour
    {
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private ItemPopupShower itemPopupShower;

    }
}