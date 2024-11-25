using SampleGame;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private ProductPopupView productPopupView;

    public override void InstallBindings()
    {
        Container
            .Bind<ProductPopupView>()
            .FromInstance(productPopupView)
            .AsSingle();
        
        Container
            .BindInterfacesTo<ItemPresenter>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<ItemPopupShower>()
            .AsSingle()
            .NonLazy();
    }
}