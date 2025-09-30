using SimpleGame;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create equipment and manager
        Equipment equipment = new Equipment();
        EquipmentManager equipmentManager = new EquipmentManager(equipment);

        // Create test items
        var sword = new Item { Id = 1, Name = "Iron Sword", Type = ItemType.Weapon, Rarity = ItemRarity.Common };
        var armor = new Item { Id = 2, Name = "Leather Armor", Type = ItemType.Armor, Rarity = ItemRarity.Common };

        // Test through manager
        Console.WriteLine("Testing Equipment System with Manager:\n");

        equipment.DisplayEquipment();
        Console.WriteLine();

        Console.WriteLine("Equipping sword through manager...");
        equipmentManager.EquipItem(sword);

        Console.WriteLine("\nEquipping armor through manager...");
        equipmentManager.EquipItem(armor);

        Console.WriteLine();
        equipment.DisplayEquipment();

        // Test manager-specific methods
        Console.WriteLine($"\nHas weapon equipped: {equipmentManager.HasItemEquipped(ItemType.Weapon)}");
        Console.WriteLine($"Equipped weapon: {equipmentManager.GetEquippedItem(ItemType.Weapon)?.Name}");

        Console.WriteLine("\nUnequipping armor through manager...");
        equipmentManager.UnequipItem(ItemType.Armor);

        Console.WriteLine();
        equipment.DisplayEquipment();
    }
}
