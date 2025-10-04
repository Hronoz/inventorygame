namespace InventoryGame
{
    public enum ItemType { Weapon, Armor, Consumable, Material }
    public enum ItemRarity { Common, Uncommon, Rare, Epic, Legendary }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public ItemRarity Rarity { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
    }
}
