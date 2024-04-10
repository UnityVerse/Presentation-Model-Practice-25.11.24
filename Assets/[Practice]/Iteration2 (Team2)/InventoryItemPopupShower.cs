namespace SampleGame
{
    ///Показывает попап выбранного предмета, который кликнул игрок в попапе инвентаря
    public sealed class InventoryItemPopupShower
    {
        private readonly InventoryPopup inventoryPopup;
        private readonly InventoryItemPopup inventoryItemPopup;

        public InventoryItemPopupShower(InventoryPopup inventoryPopup, InventoryItemPopup inventoryItemPopup)
        {
            this.inventoryPopup = inventoryPopup;
            this.inventoryItemPopup = inventoryItemPopup;
        }
    }
}