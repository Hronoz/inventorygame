namespace InventoryGame
{
    public interface ICharacterService
    {
        void CreateCharacter(string name);
        void GiveItem(Item item);
        void EquipItem(Item item);
        void UnequipItem(ItemType slotType);
    }
}
