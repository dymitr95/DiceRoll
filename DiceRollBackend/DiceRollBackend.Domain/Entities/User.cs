namespace DiceRollBackend.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    private User(){}

    private User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public static User Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }

        return new User(name);
    }
}