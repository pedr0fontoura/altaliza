using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;
using Altaliza.Application.Requests;

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
        public async Task<ActionResult<VehicleCategory>> Post([FromBody] CreateVehicleCategoryRequest request)
        {
            var dto = new CreateVehicleCategoryDto
            {
                Name = request.Name,
                Description = request.Description,
            };

            return await _vehicleCategoryService.CreateVehicleCategory(dto);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<VehicleCategory>>> Get()
        {
            return await _vehicleCategoryService.ListAllVehicleCategories();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<VehicleCategory>> GetById([FromRoute] int id)
        {
            return await _vehicleCategoryService.ShowVehicleCategory(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<VehicleCategory>> Put([FromRoute] int id, [FromBody] UpdateVehicleCategoryRequest request)
        {
            var dto = new UpdateVehicleCategoryDto
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
            };

            return await _vehicleCategoryService.UpdateVehicleCategory(dto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete([FromRoute] int id)
        {
            var dto = new DeleteVehicleCategoryDto
            {
                Id = id,
            };

            await _vehicleCategoryService.DeleteVehicleCategory(dto);
        }
    }
}