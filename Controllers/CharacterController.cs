using Microsoft.AspNetCore.Mvc;

namespace InventoryGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost]
        public ActionResult CreateCharacter(Character character)
        {
            _characterService.CreateCharacter(character);

            return CreatedAtAction(nameof(GetCharacter), new { name = character.Name }, character);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            Character character = _characterService.GetCharacter(id);

            if (character is null)
            {
                return NotFound();
            }

            return character;
        }

        [HttpPost("item/{id}")]
        public ActionResult GiveItem(int id, Item item)
        {
            _characterService.GiveItem(id, item);

            return NotFound();
        }

        [HttpPost("equip/{id}")]
        public ActionResult EquipItem(int id, Item item)
        {
            _characterService.EquipItem(id, item);

            return Ok();
        }

        [HttpPost("unequip/{id}")]
        public ActionResult UnequipItem(int id, ItemType slotType)
        {
            _characterService.UnequipItem(id, slotType);

            return Ok();
        }
    }
}
