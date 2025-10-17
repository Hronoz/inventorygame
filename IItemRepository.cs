namespace InventoryGame
{
    public interface IItemRepository
    {
        Item GetItem(int id);
        IEnumerable<Item> GetAllItems();
    }
}
