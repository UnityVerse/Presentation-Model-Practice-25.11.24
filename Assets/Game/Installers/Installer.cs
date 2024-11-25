using Zenject;

public class Installer : MonoInstaller
{


    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ProductPopupPresentationMock>().AsSingle().NonLazy();
    }
}