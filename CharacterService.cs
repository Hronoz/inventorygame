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

        public Character GetCharacter(string name)
        {
            return Character;
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

            Character.EquipItem(item);
        }

        public void UnequipItem(ItemType slotType)
        {
            if (Character is null)
            {
                return;
            }

            Character.UnequipItem(slotType);
        }
    }
}
