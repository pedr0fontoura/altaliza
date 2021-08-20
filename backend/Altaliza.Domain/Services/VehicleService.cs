using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Domain.Dtos;

namespace Altaliza.Domain.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task<DomainResponseDto<Vehicle>> CreateVehicle(CreateVehicleDto data)
        {
            var response = new DomainResponseDto<Vehicle>();

            var vehicleCategory = await _vehicleCategoryRepository.FindById(data.CategoryId);

            if (vehicleCategory == null)
            {
                response.AddError("categoryId", "A categoria do veículo não foi encontrada");
            }

            if (!response.HasErrors())
            {
                response.Data = await _vehicleRepository.Create(new Vehicle
                {
                    Category = vehicleCategory,
                    Name = data.Name,
                    Stock = data.Stock,
                    Image = data.Image,
                    Rent1Day = data.Rent1Day,
                    Rent7Day = data.Rent7Day,
                    Rent15Day = data.Rent15Day,
                });
            }

            return response;
        }

        public async Task<DomainResponseDto<List<Vehicle>>> ListAllVehicles()
        {
            var response = new DomainResponseDto<List<Vehicle>>
            {
                Data = await _vehicleRepository.FindAll(),
            };

            return response;
        }

        public async Task<DomainResponseDto<Vehicle>> ShowVehicle(int id)
        {
            var response = new DomainResponseDto<Vehicle>
            {
                Data = await _vehicleRepository.FindById(id),
            };

            return response;
        }

        public async Task<DomainResponseDto<Vehicle>> UpdateVehicle(UpdateVehicleDto data)
        {
            var response = new DomainResponseDto<Vehicle>();

            var vehicle = await _vehicleRepository.FindById(data.Id);
            var category = await _vehicleCategoryRepository.FindById(data.CategoryId);

            if (vehicle == null)
            {
                response.AddError("id", "Veículo não encontrado");
            }

            if (vehicle.Category.Id != data.CategoryId)
            {
                response.AddError("categoryId", "Categoria de veículo não encontrada");
            }

            if (!response.HasErrors())
            {
                vehicle.Category = category;
                vehicle.Name = data.Name;
                vehicle.Stock = data.Stock;
                vehicle.Image = data.Image;
                vehicle.Rent1Day = data.Rent1Day;
                vehicle.Rent7Day = data.Rent7Day;
                vehicle.Rent15Day = data.Rent15Day;

                response.Data = await _vehicleRepository.Update(vehicle);
            }

            return response;
        }

        public async Task<DomainResponseDto<object>> DeleteVehicle(int id)
        {
            var response = new DomainResponseDto<object>();

            await _vehicleRepository.Delete(id);

            return response;
        }
    }
}
