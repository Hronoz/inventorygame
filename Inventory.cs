using InventoryGame.Exceptions;

namespace InventoryGame
{
    public class Inventory
    {
        private readonly List<InventorySlot> _items = new List<InventorySlot>();
        public IList<InventorySlot> Items => _items.AsReadOnly();

        public int Capacity { get; set; } = 20;
        public int UsedSlots => _items.Count;
        public bool IsFull => Capacity <= UsedSlots;

        public void AddItem(Item item, int quantity = 1)
        {
            if (IsFull)
            {
                throw new InventoryIsFullException();
            }

            _items.Add(new InventorySlot { Item = item, Quantity = quantity });
        }

        public void RemoveItem(Item item)
        {
            InventorySlot slot = _items.FirstOrDefault(i => i.Item == item);

            _items.Remove(slot);
        }
    }

    public class InventorySlot
    {
        public Item Item { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
