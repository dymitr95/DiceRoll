using AutoMapper;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.DTOs.User;
using DiceRollBackend.Application.Interfaces;
using DiceRollBackend.Application.Interfaces.Services;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Domain.Interfaces.Common;

namespace DiceRollBackend.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{

    public async Task<UserDto> CreateUserAsync(string name)
    {
        var user = User.Create(name);
        
        await unitOfWork.Users.AddAsync(user);
        await unitOfWork.SaveChangesAsync();
        
        return mapper.Map<UserDto>(user);
    }

    public async Task<IReadOnlyList<UserDto>> GetAllUsersAsync()
    {
        var users = await unitOfWork.Users.ListAsync();
        return users.Select(mapper.Map<UserDto>).ToList();
    }
}