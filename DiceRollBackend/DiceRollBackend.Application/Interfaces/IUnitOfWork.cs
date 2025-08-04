using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Application.Interfaces.Repositories;

namespace DiceRollBackend.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRoomRepository<Room> Rooms { get; }
    IUserRepository<User> Users { get; }
    
    Task<int> SaveChangesAsync();
}