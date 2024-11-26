// using Modules.Inventories;
// using Sirenix.OdinInspector;
// using UnityEngine;
// using Zenject;
//
// namespace SampleGame
// {
//     //Нельзя менять!
//     public sealed class InventoryDebug : MonoBehaviour
//     {
//         [Inject]
//         [ShowInInspector, HideInEditorMode]
//         private Inventory inventory;
//
//         [Inject]
//         [ShowInInspector, HideInEditorMode]
//         private InventoryConsumer consumer;
//
//         private void OnEnable()
//         {
//             this.consumer.OnItemConsumed += this.OnConsumed;
//         }
//
//         private void OnDisable()
//         {
//             this.consumer.OnItemConsumed -= this.OnConsumed;
//         }
//
//         private void OnConsumed(InventoryItem item)
//         {
//             Debug.Log($"<color=green>{item.Title}</color> activated!");
//         }
//     }
// }