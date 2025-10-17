namespace InventoryGame.DTOs
{
    public class InventorySlotDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Quantity { get; set; }
    }
}
