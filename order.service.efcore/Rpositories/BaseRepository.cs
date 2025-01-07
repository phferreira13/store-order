using Microsoft.EntityFrameworkCore;
using order.service.efcore.Context;

namespace order.service.efcore.Rpositories;
public abstract class BaseRepository
{
    protected readonly OrderContext _context;
    public BaseRepository(OrderContext context)
    {
        _context = context;
    }

    protected virtual async Task<T> Add<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    protected virtual async Task<T> Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    protected virtual async Task<T> Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    protected virtual async Task<T?> GetById<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    protected virtual async Task<List<T>> GetAll<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }
}
