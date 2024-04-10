using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    //Нельзя менять!
    internal sealed class InventoryDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private Inventory inventory;
        
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private InventoryConsumer inventoryConsumer;
    }
}