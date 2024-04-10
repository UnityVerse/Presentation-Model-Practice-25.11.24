using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class PresentersDebug : MonoBehaviour
    {
        [InjectOptional]
        [ShowInInspector]
        private InventoryPresenter presenter;
    }
}