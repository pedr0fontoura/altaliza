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
    [Route("vehicles/categories")]
    public class VehicleCategoryController : ControllerBase
    {
        private readonly VehicleCategoryService _vehicleCategoryService;

        public VehicleCategoryController(VehicleCategoryService vehicleCategoryService)
        {
            _vehicleCategoryService = vehicleCategoryService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ApiResponseDto<VehicleCategory>>> Post([FromBody] CreateVehicleCategoryRequestDto request)
        {
            var response = new ApiResponseDto<VehicleCategory>();

            var dto = new CreateVehicleCategoryDto
            {
                Name = request.Name,
                Description = request.Description,
            };

            var domainResponse = await _vehicleCategoryService.CreateVehicleCategory(dto);

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
        public async Task<ActionResult<ApiResponseDto<List<VehicleCategory>>>> Get()
        {
            var response = new ApiResponseDto<List<VehicleCategory>>();

            var domainResponse = await _vehicleCategoryService.ListAllVehicleCategories();

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
        public async Task<ActionResult<ApiResponseDto<VehicleCategory>>> GetById([FromRoute] int id)
        {
            var response = new ApiResponseDto<VehicleCategory>();

            var domainResponse = await _vehicleCategoryService.ShowVehicleCategory(id);

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
        public async Task<ActionResult<ApiResponseDto<VehicleCategory>>> Put([FromRoute] int id, [FromBody] UpdateVehicleCategoryRequestDto request)
        {
            var response = new ApiResponseDto<VehicleCategory>();

            var dto = new UpdateVehicleCategoryDto
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
            };

            var domainResponse = await _vehicleCategoryService.UpdateVehicleCategory(dto);

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

            var dto = new DeleteVehicleCategoryDto
            {
                Id = id,
            };

            var domainResponse = await _vehicleCategoryService.DeleteVehicleCategory(dto);

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