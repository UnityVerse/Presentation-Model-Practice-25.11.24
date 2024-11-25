namespace SampleGame
{
	using System;
	using Modules.Inventories;
	using UnityEngine;

	public class ItemPresenterMock : IItemPresenter
	{
		InventoryItem _cfg;
		
		public event Action OnShow;
		public Sprite Icon => _cfg.Icon;
		public string Title => _cfg.Title;
		public string Description => _cfg.Decription;
		public string Count { get; } = "1";

		
		public void Show(InventoryItem cfg)
		{
			_cfg = cfg;
			OnShow?.Invoke();
		}

		public void TryConsume()
		{
			Debug.Log("Consumed");
		}
	}
}