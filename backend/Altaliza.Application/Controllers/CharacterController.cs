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
        public async Task<ActionResult<ApiResponseDto<Character>>> Post([FromBody] CreateCharacterRequestDto request)
        {
            var response = new ApiResponseDto<Character>();

            var dto = new CreateCharacterDto
            {
                Name = request.Name,
                Wallet = (float) request.Wallet,
            };

            var domainResponse = await _characterService.CreateCharacter(dto);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = domainResponse.Data;

                return Ok(response);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ApiResponseDto<List<Character>>>> Get()
        {
            var response = new ApiResponseDto<List<Character>>();

            var domainResponse = await _characterService.ListCharacters();

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = domainResponse.Data;

                return Ok(response);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponseDto<Character>>> GetById([FromRoute] int id)
        {
            var response = new ApiResponseDto<Character>();

            var domainResponse = await _characterService.ShowCharacter(id);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = domainResponse.Data;

                return Ok(response);
            }
        }
    }
}