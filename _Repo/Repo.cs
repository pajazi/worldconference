using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class Repo<TEntity, TContext>
        where TEntity : class, IModel
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repo(TContext context)
        {
            _context = context;
        }

		public async Task<List<TEntity>> Get()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return entity;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}