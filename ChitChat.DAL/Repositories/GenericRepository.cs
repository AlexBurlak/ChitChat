using System.Linq.Expressions;
using ChitChat.Core.Entities;
using ChitChat.DAL.Context;
using ChitChat.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChitChat.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ChitChatContext _context;

    public GenericRepository(ChitChatContext context)
    {
        _context = context;
    }
    public async Task<T> GetAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>()
            .Where(expression)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> range)
    {
        await _context.Set<T>().AddRangeAsync(range);
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