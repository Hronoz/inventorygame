using Microsoft.AspNetCore.Mvc;

namespace InventoryGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetItems()
        {
            return _itemRepository.GetAllItems().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            return _itemRepository.GetItem(id);
        }
    }
}
