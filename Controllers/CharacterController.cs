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

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            Character character = _characterService.GetCharacter(id);

            return character;
        }

        [HttpPost]
        public ActionResult CreateCharacter(Character character)
        {
            _characterService.CreateCharacter(character);

            return CreatedAtAction(nameof(GetCharacter), new { name = character.Name }, character);
        }
    }
}
