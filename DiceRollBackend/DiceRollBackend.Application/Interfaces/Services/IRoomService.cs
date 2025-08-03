using DiceRollBackend.Application.DTOs;

namespace DiceRollBackend.Application.Interfaces.Services;

public interface IRoomService
{
    Task<RoomDto?> GetRoomByCodeAsync(string code);
}