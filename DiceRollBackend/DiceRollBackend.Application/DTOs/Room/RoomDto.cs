using DiceRollBackend.Application.DTOs.User;

namespace DiceRollBackend.Application.DTOs.Room;

public class RoomDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public IReadOnlyList<UserDto> Users { get; set; } = null!;
    public UserDto ActiveUser { get; set; } = null!;
}