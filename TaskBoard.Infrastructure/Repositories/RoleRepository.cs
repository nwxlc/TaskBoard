using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role> TryGetById(Guid id)
    {
        return await _context.Roles
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("Role not found");
    }
}