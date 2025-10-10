using System.Collections;

namespace InventoryGame
{
    public class Inventory
    {
        private readonly List<InventorySlot> _items = new List<InventorySlot>();
        public IList<InventorySlot> Items => _items.AsReadOnly();

        public int Capacity { get; set; } = 20;
        public int UsedSlots => _items.Count;
        public bool IsFull => Capacity <= UsedSlots;

        /// <summary>
        /// Adds item to inventory if inventory is not full
        /// </summary>
        /// <param name="item">Item that is to be added</param>
        /// <param name="quantity">Quantity of items that is to be added</param>
        /// <returns>true it item is added, false if not</returns>
        public bool AddItem(Item item, int quantity = 1)
        {
            if (UsedSlots < Capacity)
            {
                _items.Add(new InventorySlot { Item = item, Quantity = quantity });
                return true;
            }
            return false;
        }

        public void RemoveItem(int itemId, int quantity = 1) { }
    }

    public class InventorySlot
    {
        public Item Item { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
