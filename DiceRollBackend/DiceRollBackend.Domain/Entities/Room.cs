namespace DiceRollBackend.Domain.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    
    
    
    private Room(){}

    private Room(string code)
    {
        Id = Guid.NewGuid();
        Code = code;
    }

    public static Room Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code is required");
        }

        return new Room(code);
    }
}