namespace InventoryGame.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id)
            : base($"Character with Id {id} was not found.") { }
    }
}
