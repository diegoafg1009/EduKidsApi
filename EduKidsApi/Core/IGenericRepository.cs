namespace EduKidsApi.Core;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> CreateAsync(T entity);
    Task<IEnumerable<T>> CreateRangeAsync(List<T> items);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}