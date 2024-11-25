namespace Game.Scripts.Installers
{
	using Modules.Inventories;
	using SampleGame;
	using UnityEngine;
	using Zenject;

	public class UiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.Bind<ItemPopupShower>()
				.AsSingle();
			
			Container
				.BindInterfacesAndSelfTo<ItemPresenterMock>()
				.AsSingle();
			
			Container
				.BindInterfacesTo<ItemPopup>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}