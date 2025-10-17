using InventoryGame.Exceptions;
using InventoryGame.Models;

namespace InventoryGame
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new() {
            new Item { Id = 1, Name = "Sword", Type = ItemType.Weapon },
            new Item { Id = 2, Name = "Shield", Type = ItemType.Armor },
            new Item { Id = 3, Name = "Potion", Type = ItemType.Consumable }
        };

        public Item GetItem(int id)
        {
            Item? item = _items.FirstOrDefault(i => i.Id == id);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            return item;
        }

        public IEnumerable<Item> GetAllItems() => _items;
    }
}
