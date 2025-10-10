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
            Character? character = _characters.Find(ch => ch.Id == id);

            if (character is null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public void GiveItem(int id, Item item)
        {
            Character character = GetCharacter(id);

            character.Inventory.AddItem(item);
        }

        public void EquipItem(int id, Item item)
        {
            Character character = GetCharacter(id);

            if (!character.Inventory.Items.Any(i => i.Item == item))
            {
                throw new ItemNotOwnedException(id, item.Id);
            }

            character.EquipItem(item);
        }

        public void UnequipItem(int id, ItemType slotType)
        {
            Character character = GetCharacter(id);

            if (character.Inventory.IsFull)
            {
                throw new InventoryIsFullException(id);
            }

            character.UnequipItem(slotType);
        }
    }
}
