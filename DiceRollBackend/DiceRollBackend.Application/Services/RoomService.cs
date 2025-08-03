using DiceRollBackend.Application.DTOs;
using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Services;

namespace DiceRollBackend.Application.Services;

public class RoomService(IUnitOfWork unitOfWork) : IRoomService
{

    public async Task<RoomDto?> GetRoomByCodeAsync(string code)
    {
        var room = await unitOfWork.Rooms.GetRoomByCodeAsync(code);
        return room == null ? null : new RoomDto()
        {
            Id = room.Id,
            Code = room.Code
        };
    }
    
}