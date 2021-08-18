using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Infra.Context;

namespace Altaliza.Infra.Repositories
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
    }
}
