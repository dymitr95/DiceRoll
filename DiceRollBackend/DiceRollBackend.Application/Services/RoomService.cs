using AutoMapper;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Services;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Domain.Interfaces.Common;

namespace DiceRollBackend.Application.Services;

public class RoomService(IUnitOfWork unitOfWork, IRoomCodeGenerator roomCodeGenerator, IMapper mapper) : IRoomService
{

    public async Task<RoomDto?> GetRoomByCodeAsync(string code)
    {
        var room = await unitOfWork.Rooms.GetRoomByCodeAsync(code.ToUpper());
        return mapper.Map<RoomDto>(room);
    }

    public async Task<RoomDto> CreateRoomAsync()
    {
        var roomCode = roomCodeGenerator.GenerateRoomCode();
        
        var room = Room.Create(roomCode);
        
        await unitOfWork.Rooms.AddAsync(room);
        await unitOfWork.SaveChangesAsync();
        
        return mapper.Map<RoomDto>(room);
    }

    public async Task<IReadOnlyList<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await unitOfWork.Rooms.ListAsync();
        return rooms.Select(mapper.Map<RoomDto>).ToList();
    }
}