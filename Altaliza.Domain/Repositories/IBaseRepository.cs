using System.Collections.Generic;
using Altaliza.Domain.Entities;

namespace Altaliza.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        IList<T> FindAll();

        T FindById(int id);
    }
}
