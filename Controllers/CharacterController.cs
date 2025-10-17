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

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
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

        [HttpPost("{characterId}/inventory/{itemId}")]
        public ActionResult GiveItem(int characterId, int itemId)
        {
            Character character = _characterService.GetCharacter(characterId);
            Item? item = character.Inventory.Items.FirstOrDefault(i => i.Item.Id == itemId)?.Item;

            if (item is null)
            {
                throw new ItemNotOwnedException(characterId, itemId);
            }

            _characterService.GiveItem(character, item);

            return Ok(character);
        }

        [HttpPost("{characterId}/equipment/{itemId}")]
        public ActionResult EquipItem(int characterId, int itemId)
        {
            Character character = _characterService.GetCharacter(characterId);
            Item? item = character.Inventory.Items.FirstOrDefault(i => i.Item.Id == itemId)?.Item;

            if (item is null)
            {
                throw new ItemNotOwnedException(characterId, itemId);
            }

            _characterService.EquipItem(character, item);

            return Ok(new { message = $"{item.Name} equipped successfully." });
        }

        [HttpDelete("{characterId}/equipment/{slotType}")]
        public ActionResult UnequipItem(int characterId, ItemType slotType)
        {
            Character character = _characterService.GetCharacter(characterId);

            _characterService.UnequipItem(character, slotType);

            return Ok(new { message = $"{slotType} unequipped successfully" });
        }
    }
}
