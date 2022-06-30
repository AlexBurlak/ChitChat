using System.Linq.Expressions;
using ChitChat.Core.Entities;

namespace ChitChat.DAL.Interfaces;

public interface IGenericRepository<T> where T : class
{
    public Task<T> GetAsync(Guid id);
    public Task<ICollection<T>> GetAllAsync();
    public Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> range);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> range);
}