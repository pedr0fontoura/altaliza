using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Domain.Dtos;

namespace Altaliza.Domain.Services
{
    public class VehicleCategoryService
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public VehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        public async Task<DomainResponseDto<VehicleCategory>> CreateVehicleCategory(CreateVehicleCategoryDto data)
        {
            var response = new DomainResponseDto<VehicleCategory>();

            var vehicleCategory = await _vehicleCategoryRepository.Create(new VehicleCategory
            {
                Name = data.Name,
                Description = data.Description,
            });

            response.Data = vehicleCategory;

            return response;
        }

        public async Task<DomainResponseDto<List<VehicleCategory>>> ListAllVehicleCategories()
        {
            var response = new DomainResponseDto<List<VehicleCategory>>()
            {
                Data = await _vehicleCategoryRepository.FindAll(),
            };

            return response;
        }

        public async Task<DomainResponseDto<VehicleCategory>> ShowVehicleCategory(int id)
        {
            var response = new DomainResponseDto<VehicleCategory>()
            {
                Data = await _vehicleCategoryRepository.FindById(id),
            };

            return response;
        }

        public async Task<DomainResponseDto<VehicleCategory>> UpdateVehicleCategory(UpdateVehicleCategoryDto data)
        {
            var response = new DomainResponseDto<VehicleCategory>();

            var vehicleCategory = await _vehicleCategoryRepository.FindById(data.Id);

            if (vehicleCategory == null)
            {
                response.AddError("vehicleCategoryId", "A categoria não foi encontrada");
            }

            if (!response.HasErrors())
            {
                vehicleCategory.Name = data.Name;
                vehicleCategory.Description = data.Description;

                response.Data = await _vehicleCategoryRepository.Update(vehicleCategory);
            }

            return response;
        }

        public async Task<DomainResponseDto<object>> DeleteVehicleCategory(DeleteVehicleCategoryDto data)
        {
            var response = new DomainResponseDto<object>();

            await _vehicleCategoryRepository.Delete(data.Id);

            return response;
        }
    }
}
