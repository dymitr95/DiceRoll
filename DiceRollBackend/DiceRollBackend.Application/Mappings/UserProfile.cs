using AutoMapper;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.DTOs.User;
using DiceRollBackend.Domain.Entities;

namespace DiceRollBackend.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}