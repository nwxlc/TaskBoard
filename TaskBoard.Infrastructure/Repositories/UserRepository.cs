using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(User userEntity)
    {
        await _context.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> TryGetByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email)
           ?? throw new Exception();
    }

    public async Task<User> TryGetById(Guid id)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new Exception();
    }
    
    public async Task Update(User entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}