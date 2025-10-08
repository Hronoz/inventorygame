namespace InventoryGame
{
    public interface ICharacterService
    {
        void CreateCharacter(Character character);
        Character GetCharacter(int id);
        void GiveItem(int id, Item item);
        void EquipItem(int id, Item item);
        void UnequipItem(int id, ItemType slotType);
    }
}
