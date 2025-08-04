using DiceRollBackend.Application.Interfaces.Repositories;
using DiceRollBackend.Domain.Entities;
using DiceRollBackend.Persistence.DbContexts;

namespace DiceRollBackend.Persistence.Repositories;

public class UserRepository<T>(AppDbContext context) : Repository<User>(context), IUserRepository<User>
{
    private readonly AppDbContext _context = context;
}