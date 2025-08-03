using DiceRollBackend.Application.DTOs.Room;

namespace DiceRollBackend.Application.Interfaces.Services;

public interface IRoomService
{
    Task<RoomDto?> GetRoomByCodeAsync(string code);
}