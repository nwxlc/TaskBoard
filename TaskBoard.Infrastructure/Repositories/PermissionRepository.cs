using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Permission> TryGetById(Guid id)
    {
        return await _context.Permissions
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("Permission not found");
    }
}