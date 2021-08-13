using System.Threading.Tasks;
using System.Collections.Generic;
using Altaliza.Domain.Entities;

namespace Altaliza.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        Task<T> FindById(int id);

        Task<IList<T>> FindAll();
    }
}
