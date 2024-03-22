using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Repositories;

public class SprintRepository : ISprintRepository
{
    private readonly AppDbContext _context;

    public SprintRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Sprint entity)
    {
        await _context.Sprints.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
    
    public async Task<Sprint> GetById(Guid id)
    {
        return await _context.Sprints
                .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new ArgumentException("Sprint not found");
    }

    public async Task<Sprint[]> SearchByTitle(string? title, int page, int pageSize)
    {
        var sprints = _context.Sprints.AsQueryable();
        if (title != null)
        {
            sprints = sprints
                .Where(x => EF.Functions.ILike(x.Title, $"%{title}%"));
        }
        
        return await sprints.OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToArrayAsync();
    }
    
    public async Task<Guid> Update(Sprint entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var countDeletedRows = await _context.Sprints.Where(x => x.Id == id).ExecuteDeleteAsync();
        if (countDeletedRows == 0)
        {
            throw new ArgumentException("Sprint not found");
        }
    }
}