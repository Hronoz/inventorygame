using InventoryGame.Models;

namespace InventoryGame.DTOs
{
    public class EquipmentDto
    {
        public Dictionary<ItemType, ItemDto?> Equipment { get; set; }
    }
}
