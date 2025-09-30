namespace SimpleGame
{
    public class CharacterManager
    {
        public Character Character { get; set; }
        public void EquipItem(Item item)
        {
            switch (item.Type)
            {
                case ItemType.Weapon:
                    break;
                case ItemType.Armor:
                    break;
            }
        }

        public void UnequipItem(int itemId)
        {
            // Remove specific quantity of an item
        }
    }
}
