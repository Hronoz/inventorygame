using AutoMapper;
using InventoryGame.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemsController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetItems()
        {
            return _mapper.Map<List<ItemDto>>(_itemRepository.GetAllItems());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(int id)
        {
            return _mapper.Map<ItemDto>(_itemRepository.GetItem(id));
        }
    }
}
