namespace SampleGame
{
    ///Представляет предмет инвентаря
    internal sealed class InventoryItemPresenter : IInventoryItemPresenter
    {
        private readonly IInventoryConsumer itemConsumer;
        private readonly IInventory.ICell cell;

        public InventoryItemPresenter(IInventory.ICell cell, IInventoryConsumer itemConsumer)
        {
            this.cell = cell;
            this.itemConsumer = itemConsumer;
        }
    }
}