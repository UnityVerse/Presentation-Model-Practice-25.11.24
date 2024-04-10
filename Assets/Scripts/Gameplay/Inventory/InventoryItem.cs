using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace SampleGame
{
    //Нельзя менять!
    //Предмет игрока
    [CreateAssetMenu(
        fileName = "InventoryItem",
        menuName = "Gameplay/Inventory/New InventoryItem"
    )]
    public sealed class InventoryItem : ScriptableObject
    {
        [field: SerializeField]
        public string Title { get; private set; }

        [field: TextArea]
        [field: SerializeField]
        public string Decription { get; private set; }
        
        [field: PreviewField]
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        
        [field: SerializeField]
        public bool IsConsumable { get; private set; }
    }
}