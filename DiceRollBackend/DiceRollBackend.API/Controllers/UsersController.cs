using DiceRollBackend.Application.DTOs.API;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.DTOs.User;
using DiceRollBackend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DiceRollBackend.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUserService userService) : ControllerBase
{
   
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(ApiResponse<IReadOnlyList<UserDto>>.Success(users));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
    {
        var user = await userService.CreateUserAsync(userRequest.Name);
        return Ok(ApiResponse<UserDto>.Success(user));
    }
}