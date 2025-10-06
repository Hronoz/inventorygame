namespace InventoryGame
{
    public class CharacterService : ICharacterService
    {
        public Character? Character { get; set; }

        public void CreateCharacter(string name)
        {
            Character = new Character
            {
                Name = name
            };
        }

        public void GiveItem(Item item)
        {
            if (Character is null)
            {
                return;
            }
            Character.Inventory.AddItem(item);
        }

        public void EquipItem(Item item)
        {
            if (Character is null)
            {
                return;
            }
            Character.Equipment.Equip(item);
        }
        public void UnequipItem(ItemType slotType)
        {
            if (Character is null)
            {
                return;
            }
            Character.Equipment.Unequip(slotType);
        }

    }
}
