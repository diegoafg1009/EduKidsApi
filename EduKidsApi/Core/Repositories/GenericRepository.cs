using EduKidsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EduKidsApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        internal DbSet<T> DbSet;

        protected GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        
        public virtual async Task<T?> CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            DbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
