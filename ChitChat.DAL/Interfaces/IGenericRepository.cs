using System.Linq.Expressions;
using ChitChat.Core.Entities;

namespace ChitChat.DAL.Interfaces;

public interface IGenericRepository<T> where T : class
{
    public T Get(Guid id);
    public ICollection<T> GetAll();
    public ICollection<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> range);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> range);
}