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
    [Route("vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ApiResponseDto<Vehicle>>> Post([FromBody] CreateVehicleRequestDto request)
        {
            var response = new ApiResponseDto<Vehicle>();

            var dto = new CreateVehicleDto
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Stock = request.Stock,
                Image = request.Image,
                Rent1Day = request.Rent1Day,
                Rent7Day = request.Rent7Day,
                Rent15Day = request.Rent15Day,
            };

            var domainResponse = await _vehicleService.CreateVehicle(dto);

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
        public async Task<ActionResult<ApiResponseDto<List<Vehicle>>>> Get()
        {
            var response = new ApiResponseDto<List<Vehicle>>();

            var domainResponse = await _vehicleService.ListAllVehicles();

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
        public async Task<ActionResult<ApiResponseDto<Vehicle>>> GetById([FromRoute] int id)
        {
            var response = new ApiResponseDto<Vehicle>();

            var domainResponse = await _vehicleService.ShowVehicle(id);

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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponseDto<Vehicle>>> Put([FromRoute] int id, [FromBody] UpdateVehicleRequestDto request)
        {
            var response = new ApiResponseDto<Vehicle>();

            var dto = new UpdateVehicleDto
            {
                Id = id,
                CategoryId = request.CategoryId,
                Name = request.Name,
                Stock = request.Stock,
                Image = request.Image,
                Rent1Day = request.Rent1Day,
                Rent7Day = request.Rent7Day,
                Rent15Day = request.Rent15Day,
            };

            var domainResponse = await _vehicleService.UpdateVehicle(dto);

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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponseDto<object>>> Delete([FromRoute] int id)
        {
            var response = new ApiResponseDto<object>();

            var domainResponse = await _vehicleService.DeleteVehicle(id);

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
    }
}