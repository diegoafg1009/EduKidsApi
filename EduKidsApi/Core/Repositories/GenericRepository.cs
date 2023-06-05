using EduKidsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EduKidsApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public virtual async Task<T?> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
