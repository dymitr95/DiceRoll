using DiceRollBackend.Application.DTOs.API;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DiceRollBackend.API.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
   
    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await roomService.GetAllRoomsAsync();
        return Ok(ApiResponse<IReadOnlyList<RoomDto>>.Success(rooms));
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> GetRoomByCode(string code)
    {
        var room = await roomService.GetRoomByCodeAsync(code);
        if (room == null)
        {
            return NotFound(ApiResponse<RoomDto>.Fail($"Room with code {code} not found"));
        }
        return Ok(ApiResponse<RoomDto>.Success(room));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomWithUserRequest request)
    {
        var room = await roomService.CreateRoomWithUserAsync(request.UserName);
        return Ok(ApiResponse<RoomDto>.Success(room));
    }
}