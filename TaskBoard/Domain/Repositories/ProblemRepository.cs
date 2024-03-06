using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain.Repositories;

public class ProblemRepository : IProblemRepository
{
    private readonly AppDbContext _context;

    public ProblemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(ProblemEntity entity)
    {
        await _context.Problems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<ProblemEntity> GetById(Guid id)
    {
        return await _context.Problems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ProblemEntity> GetByTitle(string title)
    {
        return await _context.Problems.FirstOrDefaultAsync(x => x.Title == title);
    }
    
    public async Task<ProblemEntity> Update(ProblemEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Guid id)
    {
        var problemToDelete = await _context.Problems.FirstOrDefaultAsync(x => x.Id == id);
        if (problemToDelete != null)
        {
            _context.Problems.Remove(problemToDelete);
            await _context.SaveChangesAsync();
        }
    }
}