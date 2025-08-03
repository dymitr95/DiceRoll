using DiceRollBackend.Domain.Entities;

namespace DiceRollBackend.Application.Interfaces.Repositories;

public interface IRoomRepository<T> : IRepository<Room>
{
    Task<Room?> GetRoomByCode(string code);
}