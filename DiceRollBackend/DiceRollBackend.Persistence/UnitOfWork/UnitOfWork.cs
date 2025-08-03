using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Persistence.DbContexts;
using DiceRollBackend.Persistence.Repositories;

namespace DiceRollBackend.Persistence.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public IRepository<Room> Rooms { get; } = new Repository<Room>(context);

    
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    
}