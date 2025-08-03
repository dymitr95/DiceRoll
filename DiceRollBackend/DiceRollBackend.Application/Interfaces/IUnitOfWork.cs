using DiceRollBackend.Domain.Entities;

namespace DiceRollBackend.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Room> Rooms { get; }
    
    Task<int> SaveChangesAsync();
}