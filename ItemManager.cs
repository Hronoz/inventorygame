namespace InventoryGame
{
    public class ItemManager
    {
        private List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items.AsReadOnly();


        public void RemoveItem(int id)
        {
            Item itemToDelete = _items.SingleOrDefault(i => i.Id == id);

            if (itemToDelete != null)
            {
                _items.Remove(itemToDelete);
            }
        }
    }
}
