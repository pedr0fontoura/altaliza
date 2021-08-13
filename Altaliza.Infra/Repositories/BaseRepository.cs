using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Infra.Context;

namespace Altaliza.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _context;
        protected DbSet<TEntity> _set;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _context = mySqlContext;
            _set = _context.Set<TEntity>();
        }

        public async void Create(TEntity entity)
        {
            _set.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<TEntity>> FindAll()
        {
            IQueryable<TEntity> query = _set;
            return await query.ToListAsync();
        }

        public async void Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var entity = await FindById(id);

            _set.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
