namespace Game.Scripts
{
	using Modules.Inventories;
	using SampleGame;
	using UnityEngine;
	using Zenject;

	public class _test : MonoBehaviour
	{
		[SerializeField] private InventoryItem _item;
		
		[Inject] ItemPopupShower _shower;
		
		void OnEnable()
		{
			_shower.Show(_item);  
		}
	}
}