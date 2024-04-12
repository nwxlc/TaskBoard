using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Repositories;

public class ProblemRepository : IProblemRepository
{
    private readonly AppDbContext _context;

    public ProblemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Problem entity)
    {
        await _context.Problems.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Problem[]> SearchByTitle(string? title, int page, int pageSize)
    {
        var problems = _context.Problems.AsQueryable();
        if (title != null)
        {
            problems = problems
                .Where(x => EF.Functions.ILike(x.Title, $"%{title}%"));
        }
        
        return await problems.OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToArrayAsync();
    }
    
    public async Task<Problem> GetById(Guid id)
    {
        return await _context.Problems
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("Problem not found");
    }
    
    public async Task<Guid> Update(Problem entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var countDeletedRows = await _context.Problems.Where(x => x.Id == id).ExecuteDeleteAsync();
        if (countDeletedRows == 0)
        {
            throw new ArgumentException("Problem not found");
        }
    }
}