using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;
using Altaliza.Application.Dtos;

namespace Altaliza.Application.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Character>> Post([FromBody] CreateCharacterRequestDto request)
        {
            var dto = new CreateCharacterDto
            {
                Name = request.Name,
                Wallet = request.Wallet,
            };

            return await _characterService.CreateCharacter(dto);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return await _characterService.ListAllCharacters();
        }
    }
}