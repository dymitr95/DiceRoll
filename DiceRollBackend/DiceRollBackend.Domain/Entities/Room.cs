namespace DiceRollBackend.Domain.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    
    private readonly List<User> _users = new();
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

    public Guid? ActiveUserId { get; private set; }
    public User? ActiveUser { get; private set; }
    
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
    
    public void AddUser(User user)
    {
        if (_users.All(u => u.Id != user.Id))
            _users.Add(user);
    }

    public void SetActiveUser(User user)
    {
        if (!_users.Contains(user))
            throw new InvalidOperationException("User must be part of the room");
        ActiveUserId = user.Id;
        ActiveUser = user;
    }
}