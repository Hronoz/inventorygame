namespace InventoryGame.Models
{
    public class Equipment
    {
        // private List<EquipmentSlot> _slots = [new EquipmentSlot { SlotType = ItemType.Armor }, new EquipmentSlot { SlotType = ItemType.Weapon }];
        public Dictionary<ItemType, Item?> Slots { get; private set; } = new()
        {
            { ItemType.Armor, null },
            { ItemType.Weapon, null }
        };

        public Item? Armor => Slots[ItemType.Armor];
        public Item? Weapon => Slots[ItemType.Weapon];
        public int Capacity => Slots.Count;

        // public IReadOnlyDictionary<ItemType, Item?> Slots => _slots.AsReadOnly();
        // public int Capacity => _slots.Count;
        // public Item Armor => _slots[ItemType.Armor];
        // public Item Weapon => _slots[ItemType.Weapon];
    }
}
