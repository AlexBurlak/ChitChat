using System.Linq.Expressions;
using ChitChat.Core.Entities;
using ChitChat.DAL.Context;
using ChitChat.DAL.Interfaces;

namespace ChitChat.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ChitChatContext _context;

    public GenericRepository(ChitChatContext context)
    {
        _context = context;
    }
    public T Get(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public ICollection<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public ICollection<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> range)
    {
        _context.Set<T>().AddRange(range);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> range)
    {
        _context.Set<T>().RemoveRange(range);
    }
}