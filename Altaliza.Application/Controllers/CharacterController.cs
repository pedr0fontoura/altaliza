using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;

namespace Altaliza.Application.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Character>> Post([FromServices] CharacterService characterService, [FromBody] CreateCharacterDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }

            return await characterService.CreateCharacter(data);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Character>>> Get([FromServices] CharacterService characterService)
        {
            return await characterService.ListAllCharacters();
        }
    }
}