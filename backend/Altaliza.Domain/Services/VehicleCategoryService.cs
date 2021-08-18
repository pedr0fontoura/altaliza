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

        public async Task<VehicleCategory> CreateVehicleCategory(CreateVehicleCategoryDto data)
        {
            var vehicleCategory = await _vehicleCategoryRepository.Create(new VehicleCategory
            {
                Name = data.Name,
                Description = data.Description,
            });

            return vehicleCategory;
        }

        public async Task<List<VehicleCategory>> ListAllVehicleCategories()
        {
            return await _vehicleCategoryRepository.FindAll();
        }

        public async Task<VehicleCategory> ShowVehicleCategory(int id)
        {
            return await _vehicleCategoryRepository.FindById(id);
        }

        public async Task<VehicleCategory> UpdateVehicleCategory(UpdateVehicleCategoryDto data)
        {
            var vehicleCategory = await _vehicleCategoryRepository.FindById(data.Id);

            if (vehicleCategory == null)
            {
                throw new Exception("A categoria não foi encontrada");
            }

            vehicleCategory.Name = data.Name;
            vehicleCategory.Description = data.Description;

            return await _vehicleCategoryRepository.Update(vehicleCategory);
        }

        public async Task DeleteVehicleCategory(DeleteVehicleCategoryDto data)
        {
            await _vehicleCategoryRepository.Delete(data.Id);
        }
    }
}
