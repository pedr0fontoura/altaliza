using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Infra.Context;

namespace Altaliza.Infra.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public override async Task<Vehicle> FindById(int id)
        {
            return await _set.Include(vehicle => vehicle.Category).FirstAsync(vehicle => vehicle.Id == id);
        }

        public override async Task<List<Vehicle>> FindAll()
        {
            IQueryable<Vehicle> query = _set;

            return await query.Include(vehicle => vehicle.Category).ToListAsync();
        }
    }
}