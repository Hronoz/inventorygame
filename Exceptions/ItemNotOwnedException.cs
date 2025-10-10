namespace InventoryGame.Exceptions
{
    public class ItemNotOwnedException : Exception
    {
        public ItemNotOwnedException(int characterId, int itemId)
            : base($"Character with Id {characterId} doesn't own item with Id {itemId}.") { }
    }
}
