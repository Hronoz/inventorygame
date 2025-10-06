namespace InventoryGame
{
    public class Character
    {
        public string Name { get; set; } = "Hero";
        public int Level { get; set; } = 1;
        public Inventory Inventory { get; set; } = new Inventory();
        public Equipment Equipment { get; set; } = new Equipment();

        public int CalculateTotalDamage()
        {
            int baseDamage = 10 + (Level * 2);
            int weaponDamage = Equipment.Weapon?.Damage ?? 0;
            return baseDamage + weaponDamage;
        }

        public void EquipItem(Item item)
        {
            ItemType slotType = item.Type;
            if (Equipment.Slots.ContainsKey(slotType))
            {
                if (Equipment.Slots[slotType] is not null)
                {
                    UnequipItem(slotType);
                }
                Equipment.Slots[slotType] = item;
            }
        }

        public void UnequipItem(ItemType itemType)
        {
            if (Inventory.UsedSlots >= Inventory.Capacity)
            {
                return;
            }
            Item? item = Equipment.Slots[itemType];
            if (Inventory.AddItem(item))
            {
                Equipment.Slots[itemType] = null;
            }
        }
    }
}
