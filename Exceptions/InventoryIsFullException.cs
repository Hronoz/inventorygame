namespace InventoryGame.Exceptions
{
    public class InventoryIsFullException : Exception
    {
        public int? CharacterId { get; }

        public InventoryIsFullException()
            : base($"Inventory is full") { }

        public InventoryIsFullException(int characterId)
            : base($"Character with Id {characterId} has full inventory")
        {
            CharacterId = characterId;
        }
    }
}
