namespace SimpleGame
{
    public class ItemManager
    {
        private List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        public void ViewItem(Item item)
        {
            Console.WriteLine($"Item {item.Id} info:");
            Console.WriteLine($"Item Name: {item.Name}");
            Console.WriteLine($"Item Type: {item.Type}");
            Console.WriteLine($"Item Rarity: {item.Rarity}");
        }

        public void ViewItems()
        {
            foreach (Item item in _items)
            {
                ViewItem(item);
            }
        }

        public void AddItem()
        {
            Item item = new();
            bool success = false;
            string input;
            do
            {
                int id = 0;
                Console.WriteLine("Enter an id:");
                input = Console.ReadLine();
                success = int.TryParse(input, out id);
                if (success)
                {
                    Console.WriteLine($"Your input: {input}");
                    item.Id = id;
                }
                else
                {
                    Console.WriteLine($"Invalid Input.");
                }
            } while (!success);

            Console.WriteLine("Enter a name:");
            item.Name = Console.ReadLine() ?? "sword";
            Console.WriteLine($"Your input: {item.Name}");
            do
            {
                ItemType type = ItemType.Weapon;
                Console.WriteLine("Enter an item type:");
                input = Console.ReadLine();
                success = Enum.TryParse(input, true, out type);
                if (success)
                {
                    Console.WriteLine($"Your input: {input}");
                    item.Type = type;
                }
                else
                {
                    Console.WriteLine($"Invalid Input.");
                }
            } while (!success);

            do
            {
                ItemRarity rarity = ItemRarity.Common;
                Console.WriteLine("Enter an item rarity:");
                input = Console.ReadLine();
                success = Enum.TryParse(input, true, out rarity);
                if (success)
                {
                    Console.WriteLine($"Your input: {input}");
                    item.Rarity = rarity;
                }
                else
                {
                    Console.WriteLine($"Invalid Input.");
                }
            } while (!success);

            _items.Add(item);
        }

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
