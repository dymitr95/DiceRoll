using DiceRollBackend.Application.DTOs.Room;

namespace DiceRollBackend.Application.Interfaces.Services;

public interface IRoomService
{
    Task<RoomDto?> GetRoomByCodeAsync(string code);
    Task<RoomDto> CreateRoomAsync();
    Task<IReadOnlyList<RoomDto>> GetAllRoomsAsync();
}