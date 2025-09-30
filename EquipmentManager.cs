namespace SimpleGame
{
    public class EquipmentManager
    {
        private Equipment _equipment;

        public EquipmentManager(Equipment equipment)
        {
            _equipment = equipment;
        }

        public void EquipItem(Item item)
        {
            if (!_equipment.Slots.TryGetValue(item.Type, out Item? currentItem))
            {
                Console.WriteLine($"Cannot equip {item.Type} - no suitable slot");
                return;
            }

            if (currentItem != null)
            {
                Console.WriteLine($"{item.Type} slot is already occupied by {currentItem.Name}");
                return;
            }

            _equipment.Slots[item.Type] = item;
            Console.WriteLine($"Equipped {item.Name} in {item.Type} slot");
            return;
        }

        public void UnequipItem(ItemType slotType)
        {
            // Check if slot exists
            if (!_equipment.Slots.TryGetValue(slotType, out Item? currentItem))
            {
                Console.WriteLine($"No {slotType} slot found");
                return;
            }

            if (currentItem == null)
            {
                Console.WriteLine($"{slotType} slot is already empty");
                return;
            }

            // Unequip the item
            _equipment.Slots[slotType] = null;
            Console.WriteLine($"Unequipped {currentItem.Name} from {slotType} slot", currentItem);
            return;
        }

        public bool HasItemEquipped(ItemType slotType)
        {
            return _equipment.Slots.ContainsKey(slotType) && _equipment.Slots[slotType] != null;
        }

        public Item? GetEquippedItem(ItemType slotType)
        {
            return _equipment.Slots.TryGetValue(slotType, out Item? value) ? value : null;
        }
    }
}
