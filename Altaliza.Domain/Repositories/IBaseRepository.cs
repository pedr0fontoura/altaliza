using System.Threading.Tasks;
using System.Collections.Generic;
using Altaliza.Domain.Entities;

namespace Altaliza.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);

        Task<TEntity> FindById(int id);

        Task<List<TEntity>> FindAll();
    }
}
