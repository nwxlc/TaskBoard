using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(UserEntity userEntity)
    {
        await _context.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    
}