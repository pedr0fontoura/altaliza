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

        public async Task<DomainResponseDto<CharacterVehicle>> RentCharacterVehicle(RentCharacterVehicleDto data)
        {
            var response = new DomainResponseDto<CharacterVehicle>();

            Character character = await _characterRepository.FindById(data.CharacterId);
            Vehicle vehicle = await _vehicleRepository.FindById(data.VehicleId);

            float? rentPrice = null;
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
            }

            if (character == null)
            {
                response.AddError("characterId", "Personagem não encontrado");
            }

            if (vehicle == null)
            {
                response.AddError("vehicleId", "Veículo não encontrado");
            }

            if (rentPrice == null)
            {
                response.AddError("rentTime", "Tempo de aluguel inválido");
            }

            if (rentPrice != null && character != null && rentPrice >= character.Wallet)
            {
                response.AddError("characterId", "O personagem não tem dinheiro suficiente para alugar o veículo");

            }

            if (vehicle != null && vehicle.Stock <= 0)
            {
                response.AddError("vehicleId", "O veículo não está disponível para aluguel");
            }

            if (!response.HasErrors())
            {
                character.Wallet -= (float)rentPrice;
                vehicle.Stock -= 1;

                await _characterRepository.Update(character);
                await _vehicleRepository.Update(vehicle);

                CharacterVehicle characterVehicle = await _characterVehicleRepository.Create(new CharacterVehicle
                {
                    Character = character,
                    Vehicle = vehicle,
                    ExpirationDate = expirationDate,
                });

                response.Data = characterVehicle;
            }

            return response;
        }

        public async Task<DomainResponseDto<List<CharacterVehicle>>> ListCharacterVehiclesRentedByCharacter(int id)
        {
            var response = new DomainResponseDto<List<CharacterVehicle>>();

            var character = await _characterRepository.FindById(id);

            if (character == null)
            {
                response.AddError("characterId", "Personagem não encontrado");
            }

            if (!response.HasErrors())
            {
                response.Data = await _characterVehicleRepository.FindByCharacterId(id);
            }

            return response;
        }

        public async Task<DomainResponseDto<object>> ReturnCharacterVehicle(ReturnCharacterVehicleDto data)
        {
            var response = new DomainResponseDto<object>();

            var characterVehicle = await _characterVehicleRepository.FindById(data.CharacterVehicleId);

            if (characterVehicle == null)
            {
                response.AddError("characterVehicleId", "Veículo de personagem não encontrado");
            }

            if (characterVehicle == null && characterVehicle.Character.Id != data.CharacterId)
            {
                response.AddError("characterId", "O id do personagem não bate com o locatário do veículo.");
            }

            if (!response.HasErrors())
            {
                await _characterVehicleRepository.Delete(data.CharacterVehicleId);
            }

            return response;
        }

        public async Task<DomainResponseDto<CharacterVehicle>> RenewCharacterVehicle(RenewCharacterVehicleDto data)
        {
            var response = new DomainResponseDto<CharacterVehicle>();

            var characterVehicle = await _characterVehicleRepository.FindById(data.CharacterVehicleId);
            var character = await _characterRepository.FindById(data.CharacterId);

            float? rentPrice = null;
            DateTime expirationDate = DateTime.Now;

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
            }

            if (characterVehicle == null)
            {
                response.AddError("characterVehicleId", "Veículo de personagem não encontrado");
            }

            if (character == null)
            {
                response.AddError("characterId", "Personagem não encontrado");
            }
            else if (characterVehicle != null && characterVehicle.Character.Id != data.CharacterId)
            {
                response.AddError("characterId", "O id do personagem não bate com o locatário do veículo.");
            }

            if (rentPrice == null)
            {
                response.AddError("rentTime", "Tempo de aluguel inválido");
            }

            if (rentPrice != null && character != null && rentPrice >= character.Wallet)
            {
                response.AddError("characterId", "O personagem não tem dinheiro suficiente para alugar o veículo");
            }

            if (!response.HasErrors())
            {
                character.Wallet -= (float)rentPrice;
                characterVehicle.ExpirationDate = expirationDate;

                await _characterRepository.Update(character);
                await _characterVehicleRepository.Update(characterVehicle);

                response.Data = characterVehicle;
            }

            return response;
        }
    }
}
