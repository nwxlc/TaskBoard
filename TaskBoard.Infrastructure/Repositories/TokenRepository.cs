using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly AppDbContext _context;

    public TokenRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Create(ConfirmToken entity)
    {
        await _context.ConfirmTokens.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
    
    public async Task<ConfirmToken> TryGetById(Guid id)
    {
        return await _context.ConfirmTokens
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("Token not found");
    }
}