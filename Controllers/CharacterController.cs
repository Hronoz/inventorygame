using InventoryGame.Exceptions;
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
            try
            {
                _characterService.EquipItem(id, item);
                return Ok(new { message = $"{item.Name} equipped successfully." });
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (ItemNotOwnedException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InventoryIsFullException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // Fallback for unexpected errors
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("unequip/{id}")]
        public ActionResult UnequipItem(int id, ItemType slotType)
        {
            _characterService.UnequipItem(id, slotType);

            return Ok();
        }
    }
}
