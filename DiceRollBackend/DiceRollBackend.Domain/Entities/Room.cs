namespace DiceRollBackend.Domain.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
}