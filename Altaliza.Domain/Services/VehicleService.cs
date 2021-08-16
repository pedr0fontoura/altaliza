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

        public async Task<Vehicle> CreateVehicle(CreateVehicleDto data)
        {
            var vehicleCategory = await _vehicleCategoryRepository.FindById(data.CategoryId);

            if (vehicleCategory == null)
            {
                throw new Exception("A categoria do veículo não foi encontrada");
            }

            var vehicle = await _vehicleRepository.Create(new Vehicle
            {
                Category = vehicleCategory,
                Name = data.Name,
                Stock = data.Stock,
                Image = data.Image,
                Rent1Day = data.Rent1Day,
                Rent7Day = data.Rent7Day,
                Rent15Day = data.Rent15Day,
            });

            return vehicle;
        }

        public async Task<List<Vehicle>> ListAllVehicles()
        {
            return await _vehicleRepository.FindAll();
        }

        public async Task<Vehicle> ShowVehicle(int id)
        {
            return await _vehicleRepository.FindById(id);
        }

        public async Task<Vehicle> UpdateVehicle(UpdateVehicleDto data)
        {
            var vehicle = await _vehicleRepository.FindById(data.Id);

            if (vehicle == null)
            {
                throw new Exception("Veículo não encontrado");
            }

            if (vehicle.Category.Id != data.CategoryId)
            {
                var category = await _vehicleCategoryRepository.FindById(data.CategoryId);
                
                vehicle.Category = category ?? throw new Exception("Categoria de veículo não encontrada");
            }

            vehicle.Name = data.Name;
            vehicle.Stock = data.Stock;
            vehicle.Image = data.Image;
            vehicle.Rent1Day = data.Rent1Day;
            vehicle.Rent7Day = data.Rent7Day;
            vehicle.Rent15Day = data.Rent15Day;

            return await _vehicleRepository.Update(vehicle);
        }

        public async Task DeleteVehicle(int id)
        {
            await _vehicleRepository.Delete(id);
        }
    }
}
