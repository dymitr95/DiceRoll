using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Repositories;
using DiceRollBackend.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DiceRollBackend.Persistence.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}