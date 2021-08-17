using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Domain.Dtos;
using Altaliza.Domain.Enums;

namespace Altaliza.Domain.Services
{
    public class CharacterVehicleService
    {
        private readonly ICharacterVehicleRepository _characterVehicleRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public CharacterVehicleService(ICharacterVehicleRepository characterVehicleRepository , ICharacterRepository characterRepository, IVehicleRepository vehicleRepository)
        {
            _characterVehicleRepository = characterVehicleRepository;
            _characterRepository = characterRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<CharacterVehicle> RentCharacterVehicle(RentCharacterVehicleDto data)
        {
            Character character = await _characterRepository.FindById(data.CharacterId);

            Vehicle vehicle = await _vehicleRepository.FindById(data.VehicleId);

            bool isVehicleAvailable = vehicle.Stock > 0;
            
            float rentPrice;
            DateTime expirationDate = DateTime.Now;

            switch (data.RentTime)
            {
                case RentTime.Rent1Day:
                    rentPrice = vehicle.Rent1Day;
                    expirationDate = expirationDate.AddDays(1);
                    break;
                case RentTime.Rent7Day:
                    rentPrice = vehicle.Rent7Day;
                    expirationDate = expirationDate.AddDays(7);
                    break;
                case RentTime.Rent15Day:
                    rentPrice = vehicle.Rent15Day;
                    expirationDate = expirationDate.AddDays(15);
                    break;
                default:
                    throw new Exception("Tempo de aluguel inválido");
            }

            if (isVehicleAvailable)
            {
                vehicle.Stock -= 1;
            } else
            {
                throw new Exception("O veículo não está disponível para aluguel");
            }

            if (rentPrice <= character.Wallet)
            {
                character.Wallet -= rentPrice;
            } else
            {
                throw new Exception("O personagem não tem dinheiro suficiente para alugar o veículo");
            }

            await _characterRepository.Update(character);
            await _vehicleRepository.Update(vehicle);

            CharacterVehicle characterVehicle = await _characterVehicleRepository.Create(new CharacterVehicle
            {
                Character = character,
                Vehicle = vehicle,
                ExpirationDate = expirationDate,
            });

            return characterVehicle;
        }

        public async Task<List<CharacterVehicle>> ListCharacterVehiclesRentedByCharacter(int id)
        {
            Character character = await _characterRepository.FindById(id);

            if (character == null)
            {
                throw new Exception("Personagem não encontrado");
            }

            return await _characterVehicleRepository.FindByCharacterId(id);
        }

        public async Task ReturnCharacterVehicle(ReturnCharacterVehicleDto data)
        {
            CharacterVehicle characterVehicle = await _characterVehicleRepository.FindById(data.CharacterVehicleId);

            if (characterVehicle == null)
            {
                throw new Exception("Veículo de personagem não encontrado");
            }

            if (characterVehicle.Character.Id != data.CharacterId)
            {
                throw new Exception("O id do personagem não bate com o locatário do veículo.");
            }

            await _characterVehicleRepository.Delete(data.CharacterVehicleId);
        }

        public async Task<CharacterVehicle> RenewCharacterVehicle(RenewCharacterVehicleDto data)
        {
            CharacterVehicle characterVehicle = await _characterVehicleRepository.FindById(data.CharacterVehicleId);

            if (characterVehicle == null)
            {
                throw new Exception("Veículo de personagem não encontrado");
            }

            if (characterVehicle.Character.Id != data.CharacterId)
            {
                throw new Exception("O id do personagem não bate com o locatário do veículo.");
            }

            Character character = await _characterRepository.FindById(data.CharacterId);

            if (character == null)
            {
                throw new Exception("Personagem não encontrado");
            }

            float rentPrice;
            DateTime expirationDate = characterVehicle.ExpirationDate;

            switch (data.RentTime)
            {
                case RentTime.Rent1Day:
                    rentPrice = characterVehicle.Vehicle.Rent1Day;
                    expirationDate = expirationDate.AddDays(1);
                    break;
                case RentTime.Rent7Day:
                    rentPrice = characterVehicle.Vehicle.Rent7Day;
                    expirationDate = expirationDate.AddDays(7);
                    break;
                case RentTime.Rent15Day:
                    rentPrice = characterVehicle.Vehicle.Rent15Day;
                    expirationDate = expirationDate.AddDays(15);
                    break;
                default:
                    throw new Exception("Tempo de aluguel inválido");
            }

            if (rentPrice <= character.Wallet)
            {
                character.Wallet -= rentPrice;
            }
            else
            {
                throw new Exception("O personagem não tem dinheiro suficiente para renovar o aluguel do veículo");
            }

            characterVehicle.ExpirationDate = expirationDate;

            await _characterRepository.Update(character);
            await _characterVehicleRepository.Update(characterVehicle);

            return characterVehicle;
        }
    }
}
