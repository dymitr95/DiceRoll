using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.DTOs.User;

namespace DiceRollBackend.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(string name);
    Task<IReadOnlyList<UserDto>> GetAllUsersAsync();
}