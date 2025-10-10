namespace InventoryGame.Exceptions
{
    public class InventoryIsFullException : Exception
    {
        public InventoryIsFullException(int characterId)
            : base($"Character with Id {characterId} has full inventory") { }
    }
}
