namespace InventoryGame
{
    public interface ICharacterService
    {
        void CreateCharacter(Character character);
        Character GetCharacter(int id);
        void GiveItem(Character character, Item item);
        void EquipItem(Character character, Item item);
        void UnequipItem(Character character, ItemType slotType);
    }
}
