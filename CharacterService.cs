using InventoryGame.Exceptions;

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
            Character? character = _characters.FirstOrDefault(ch => ch.Id == id);

            if (character is null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public void GiveItem(Character character, Item item)
        {
            try
            {

                character.Inventory.AddItem(item);
            }
            catch (InventoryIsFullException)
            {
                throw new InventoryIsFullException(character.Id);
            }
        }

        public void EquipItem(Character character, Item item)
        {
            character.EquipItem(item);
        }

        public void UnequipItem(Character character, ItemType slotType)
        {
            character.UnequipItem(slotType);
        }
    }
}
