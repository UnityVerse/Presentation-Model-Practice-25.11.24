using System;

namespace SampleGame
{
    //Нельзя менять!
    //Активирует предметы игрока в инвентаре
    public interface IInventoryConsumer
    {
        event Action<InventoryItem> OnItemConsumed;

        bool CanConsume(InventoryItem item);
        void Consume(InventoryItem item);
    }
}