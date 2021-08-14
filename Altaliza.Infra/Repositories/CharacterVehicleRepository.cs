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
    }
}