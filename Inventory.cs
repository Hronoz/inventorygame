namespace SimpleGame
{
    public class Inventory
    {
        private List<InventorySlot> _slots = new List<InventorySlot>();
        public int Capacity { get; set; } = 20;
        public int UsedSlots => _slots.Count;

        public void AddItem(Item item, int quantity = 1) { }
        public void RemoveItem(int itemId, int quantity = 1) { }
        public void ViewInventory() { }
    }

    public class InventorySlot
    {
        public Item Item { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
