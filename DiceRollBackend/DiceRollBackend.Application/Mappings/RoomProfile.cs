using AutoMapper;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Domain.Entities;

namespace DiceRollBackend.Application.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<RoomDto, Room>();
    }
}