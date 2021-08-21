using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Infra.Context;

namespace Altaliza.Infra.Repositories
{
    public class CharacterVehicleRepository : BaseRepository<CharacterVehicle>, ICharacterVehicleRepository
    {
        public CharacterVehicleRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public async override Task<CharacterVehicle> FindById(int id)
        {
            IQueryable<CharacterVehicle> query = _set;

            var result = await query
                .Include(characterVehicle => characterVehicle.Character)
                .Include(characterVehicle => characterVehicle.Vehicle)
                .ThenInclude(vehicle => vehicle.Category)
                .FirstAsync(characterVehicle => characterVehicle.Id == id);

            return result;
        }

        public async Task<List<CharacterVehicle>> FindByCharacterId(int characterId)
        {
            IQueryable<CharacterVehicle> query = _set;

            var result = await query
                .Include(characterVehicle => characterVehicle.Vehicle)
                .ThenInclude(vehicle => vehicle.Category)
                .Where(characterVehicle => characterVehicle.Character.Id == characterId)
                .ToListAsync();

            return result;
        }

        public async Task<List<CharacterVehicle>> FindAllExpired()
        {
            IQueryable<CharacterVehicle> query = _set;

            var result = await query
                .Where(characterVehicle => DateTime.Compare(characterVehicle.ExpirationDate, DateTime.Now) < 0)
                .ToListAsync();

            return result;
        }
    }
}