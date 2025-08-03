using DiceRollBackend.Application.DTOs.API;
using DiceRollBackend.Application.DTOs.Room;
using DiceRollBackend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DiceRollBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
   
    [HttpGet]
    public async Task<IActionResult> GetRoomByCode([FromQuery] string code)
    {
        var room = await roomService.GetRoomByCodeAsync(code);
        if (room == null)
        {
            return NotFound(ApiResponse<RoomDto>.Fail($"Room with code {code} not found"));
        }
        return Ok(ApiResponse<RoomDto>.Success(room));
    }
}