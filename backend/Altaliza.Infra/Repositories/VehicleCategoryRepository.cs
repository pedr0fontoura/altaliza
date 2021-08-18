using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Infra.Context;

namespace Altaliza.Infra.Repositories
{
    public class VehicleCategoryRepository : BaseRepository<VehicleCategory>, IVehicleCategoryRepository
    {
        public VehicleCategoryRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
    }
}