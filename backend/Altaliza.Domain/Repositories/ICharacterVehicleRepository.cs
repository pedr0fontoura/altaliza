using System.Collections.Generic;
using System.Threading.Tasks;
using Altaliza.Domain.Entities;

namespace Altaliza.Domain.Repositories
{
    public interface ICharacterVehicleRepository : IBaseRepository<CharacterVehicle>
    {
        public Task<List<CharacterVehicle>> FindByCharacterId(int id);

        public Task<List<CharacterVehicle>> FindAllExpired();
    }
}
