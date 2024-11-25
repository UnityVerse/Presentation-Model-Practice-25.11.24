using Zenject;

namespace SampleGame
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PopupPresenterMock>()
                .AsSingle();
        }
    }
}