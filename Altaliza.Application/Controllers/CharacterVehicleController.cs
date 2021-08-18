using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;
using Altaliza.Application.Dtos;
using Altaliza.Application.ViewModels;

namespace Altaliza.Application.Controllers
{
    [ApiController]
    public class CharacterVehicleController : ControllerBase
    {
        private readonly CharacterVehicleService _characterVehicleService;

        public CharacterVehicleController(CharacterVehicleService characterVehicleService)
        {
            _characterVehicleService = characterVehicleService;
        }

        [HttpPost]
        [Route("characters/vehicles")]
        public async Task<ActionResult<CharacterVehicleResponseDto>> Post([FromBody] RentCharacterVehicleRequestDto request)
        {
            var dto = new RentCharacterVehicleDto
            {
                CharacterId = request.CharacterId,
                VehicleId = request.VehicleId,
                RentTime = request.RentTime
            };

            CharacterVehicle characterVehicle = await _characterVehicleService.RentCharacterVehicle(dto);

            return new CharacterVehicleResponseDto
            {
                Id = characterVehicle.Id,
                Vehicle = characterVehicle.Vehicle,
                ExpirationDate = characterVehicle.ExpirationDate
            };

        }

        [HttpGet]
        [Route("characters/{characterId:int}/vehicles")]
        public async Task<ActionResult<List<CharacterVehicleViewModel>>> GetByCharacterId([FromRoute] int characterId)
        {
            List<CharacterVehicle> characterVehicles = await _characterVehicleService.ListCharacterVehiclesRentedByCharacter(characterId);

            List<CharacterVehicleViewModel> viewModels = characterVehicles.Select(characterVehicle => new CharacterVehicleViewModel
            {
                Id = characterVehicle.Id,
                Vehicle = characterVehicle.Vehicle,
                ExpirationDate = characterVehicle.ExpirationDate,
            }).ToList();

            return viewModels;
        }

        [HttpDelete]
        [Route("characters/{characterId:int}/vehicles/{characterVehicleId:int}")]
        public async Task Delete([FromRoute] int characterId, [FromRoute] int characterVehicleId)
        {
            var dto = new ReturnCharacterVehicleDto
            {
                CharacterId = characterId,
                CharacterVehicleId = characterVehicleId,
            };

            await _characterVehicleService.ReturnCharacterVehicle(dto);
        }

        [HttpPost]
        [Route("characters/{characterId:int}/vehicles/{characterVehicleId:int}/renew")]
        public async Task<CharacterVehicleViewModel> Renew([FromRoute] int characterId, [FromRoute] int characterVehicleId, [FromBody] RenewCharacterVehicleRequestDto request)
        {
            var dto = new RenewCharacterVehicleDto
            {
                CharacterId = characterId,
                CharacterVehicleId = characterVehicleId,
                RentTime = request.RentTime,
            };

            CharacterVehicle characterVehicle = await _characterVehicleService.RenewCharacterVehicle(dto);

            return new CharacterVehicleViewModel
            {
                Id = characterVehicle.Id,
                Vehicle = characterVehicle.Vehicle,
                ExpirationDate = characterVehicle.ExpirationDate,
            };
        }
    }
}