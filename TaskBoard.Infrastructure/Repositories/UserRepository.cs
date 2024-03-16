using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Models;

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

    public async Task<UserEntity?> GetByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }
}