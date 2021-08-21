using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;
using Altaliza.Application.Dtos;

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
        public async Task<ActionResult<ApiResponseDto<RentCharacterVehicleResponse>>> Post([FromBody] RentCharacterVehicleRequest request)
        {
            var response = new ApiResponseDto<RentCharacterVehicleResponse>();

            var dto = new RentCharacterVehicleDto
            {
                CharacterId = request.CharacterId,
                VehicleId = request.VehicleId,
                RentTime = request.RentTime
            };

            var domainResponse = await _characterVehicleService.RentCharacterVehicle(dto);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = new RentCharacterVehicleResponse
                {
                    Id = domainResponse.Data.Id,
                    Vehicle = domainResponse.Data.Vehicle,
                    ExpirationDate = domainResponse.Data.ExpirationDate
                };

                return response;
            }
        }

        [HttpGet]
        [Route("characters/vehicles/{characterVehicleId:int}")]
        public async Task<ActionResult<ApiResponseDto<ShowCharacterVehicleResponse>>> GetById([FromRoute] int characterVehicleId)
        {
            var response = new ApiResponseDto<ShowCharacterVehicleResponse>();

            var domainResponse = await _characterVehicleService.ShowCharacterVehicle(characterVehicleId);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = new ShowCharacterVehicleResponse
                {
                    Id = domainResponse.Data.Id,
                    Vehicle = domainResponse.Data.Vehicle,
                    ExpirationDate = domainResponse.Data.ExpirationDate,
                };

                return response;
            }
        }

        [HttpGet]
        [Route("characters/{characterId:int}/vehicles")]
        public async Task<ActionResult<ApiResponseDto<List<ListCharacterRentedVehiclesResponse>>>> GetByCharacterId([FromRoute] int characterId)
        {
            var response = new ApiResponseDto<List<ListCharacterRentedVehiclesResponse>>();

            var domainResponse = await _characterVehicleService.ListCharacterVehiclesRentedByCharacter(characterId);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = domainResponse.Data.Select(characterVehicle => new ListCharacterRentedVehiclesResponse
                {
                    Id = characterVehicle.Id,
                    Vehicle = characterVehicle.Vehicle,
                    ExpirationDate = characterVehicle.ExpirationDate,
                }).ToList();

                return response;
            }
        }

        [HttpDelete]
        [Route("characters/{characterId:int}/vehicles/{characterVehicleId:int}")]
        public async Task<ActionResult> Delete([FromRoute] int characterId, [FromRoute] int characterVehicleId)
        {
            var response = new ApiResponseDto<object>();

            var dto = new ReturnCharacterVehicleDto
            {
                CharacterId = characterId,
                CharacterVehicleId = characterVehicleId,
            };

            var domainResponse = await _characterVehicleService.ReturnCharacterVehicle(dto);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        [Route("characters/{characterId:int}/vehicles/{characterVehicleId:int}/renew")]
        public async Task<ActionResult<ApiResponseDto<RenewCharacterVehicleResponse>>> Renew([FromRoute] int characterId, [FromRoute] int characterVehicleId, [FromBody] RenewCharacterVehicleRequest request)
        {
            var response = new ApiResponseDto<RenewCharacterVehicleResponse>();

            var dto = new RenewCharacterVehicleDto
            {
                CharacterId = characterId,
                CharacterVehicleId = characterVehicleId,
                RentTime = request.RentTime,
            };

            var domainResponse = await _characterVehicleService.RenewCharacterVehicle(dto);

            if (domainResponse.HasErrors())
            {
                response.Type = "error";
                response.Errors = domainResponse.Errors;
                response.Status = 400;

                return BadRequest(response);
            }
            else
            {
                response.Data = new RenewCharacterVehicleResponse
                {
                    Id = domainResponse.Data.Id,
                    Vehicle = domainResponse.Data.Vehicle,
                    ExpirationDate = domainResponse.Data.ExpirationDate,
                };

                return Ok(response);
            }
        }
    }
}