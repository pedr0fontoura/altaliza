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
        public async Task<ActionResult<Vehicle>> Post([FromBody] CreateVehicleRequestDto request)
        {
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

            return await _vehicleService.CreateVehicle(dto);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Vehicle>>> Get()
        {
            return await _vehicleService.ListAllVehicles();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Vehicle>> GetById([FromRoute] int id)
        {
            return await _vehicleService.ShowVehicle(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Vehicle>> Put([FromRoute] int id, [FromBody] UpdateVehicleRequestDto request)
        {
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

            return await _vehicleService.UpdateVehicle(dto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete([FromRoute] int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}