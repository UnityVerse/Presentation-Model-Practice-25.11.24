using UnityEngine;
using Zenject;

namespace SampleGame
{
    //Нельзя менять!
    [CreateAssetMenu(
        fileName = "InventoryInstaller",
        menuName = "Zenject/Inventory/New InventoryInstaller"
    )]
    internal sealed class InventoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private Inventory.Cell[] initialItems;
        
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<Inventory>()
                .AsSingle()
                .OnInstantiated<Inventory>((_, it) => it.SetItems(this.initialItems))
                .NonLazy();

            this.Container
                .BindInterfacesAndSelfTo<InventoryConsumer>()
                .AsSingle()
                .NonLazy();
        }
    }
}