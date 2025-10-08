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

        [HttpGet("{name}")]
        public ActionResult GetCharacter(string name)
        {
            _characterService.GetCharacter(name);

            return Ok();
        }

        [HttpPost]
        public ActionResult CreateCharacter(Character character)
        {
            _characterService.CreateCharacter(character.Name);

            return CreatedAtAction(nameof(GetCharacter), new { name = character.Name }, character);
        }
    }
}
