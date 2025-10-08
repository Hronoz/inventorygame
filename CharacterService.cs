using System.Diagnostics.Tracing;

namespace InventoryGame
{
    public class CharacterService : ICharacterService
    {
        private readonly List<Character> _characters = new();

        public void CreateCharacter(Character character)
        {
            if (_characters.Any(ch => ch.Id == character.Id))
            {
                return;
            }

            _characters.Add(character);
        }

        public Character GetCharacter(int id)
        {
            Character character = _characters.Find(ch => ch.Id == id);

            return character;
        }

        public void GiveItem(int id, Item item)
        {
            Character character = GetCharacter(id);

            if (character is null)
            {
                return;
            }

            character.Inventory.AddItem(item);
        }

        public void EquipItem(int id, Item item)
        {
            Character character = GetCharacter(id);
            if (character is null)
            {
                return;
            }

            character.EquipItem(item);
        }

        public void UnequipItem(int id, ItemType slotType)
        {
            Character character = GetCharacter(id);
            if (character is null)
            {
                return;
            }

            character.UnequipItem(slotType);
        }
    }
}
