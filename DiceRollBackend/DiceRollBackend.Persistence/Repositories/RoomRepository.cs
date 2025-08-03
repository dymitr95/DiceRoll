using DiceRollBackend.Application.Interfaces.Repositories;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DiceRollBackend.Persistence.Repositories;

public class RoomRepository<T>(AppDbContext context) : Repository<Room>(context), IRoomRepository<Room>
{
    private readonly AppDbContext _context = context;

    public async Task<Room?> GetRoomByCode(string code)
    {
        return await _context.Rooms.FirstOrDefaultAsync(r => r.Code == code);
    }
}