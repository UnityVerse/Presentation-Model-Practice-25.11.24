using System;
using System.Collections.Generic;

namespace SampleGame
{
    //Нельзя менять!
    //Хранит предметы игрока
    public interface IInventory : IEnumerable<IInventory.ICell>
    {
        event Action<ICell> OnCellAdded;
        event Action<ICell> OnCellRemoved;
        event Action OnCellsChanged;

        public interface ICell
        {
            event Action<int> OnCountChanged;
            
            InventoryItem Item { get; }
            int Count { get; }
        }
    }
}