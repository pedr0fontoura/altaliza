using System;
using System.Threading;
using System.Threading.Tasks;
using Altaliza.Domain.Services;
using Altaliza.Domain.Dtos;
using Altaliza.Domain.Repositories;

namespace Altaliza.Application.HostedServices
{
    public class ScopedCharactersVehiclesService
    {
        private readonly CharacterVehicleService _characterVehicleService;
        private readonly ICharacterVehicleRepository _characterVehicleRepository;

        public ScopedCharactersVehiclesService(CharacterVehicleService characterVehicleService, ICharacterVehicleRepository characterVehicleRepository)
        {
            _characterVehicleService = characterVehicleService;
            _characterVehicleRepository = characterVehicleRepository;
        }

        public async Task DoWorkAsync()
        {
            Console.WriteLine("[Scoped][CharatersVehicles Service] Executing");

            int count = 0;

            var expiredCharacterVehicles = await _characterVehicleRepository.FindAllExpired();

            expiredCharacterVehicles.ForEach(async expiredVehicle =>
            {
                count++;

                var dto = new RenewCharacterVehicleDto
                {
                    CharacterId = expiredVehicle.Character.Id,
                    CharacterVehicleId = expiredVehicle.Id,
                    RentTime = 0,
                };

                await _characterVehicleService.RenewCharacterVehicle(dto);
            });

            Console.WriteLine($"[Scoped][CharatersVehicles Service] Renewed {count} expired CharacterVehicles");
        }
    }
}