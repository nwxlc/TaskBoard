using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Repositories;

public class ProblemRepository : IProblemRepository
{
    private readonly AppDbContext _context;

    public ProblemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Problem entity)
    {
        await _context.Problems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Problem> GetById(Guid id)
    {
        return await _context.Problems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Problem> GetByTitle(string title)
    {
        return await _context.Problems.FirstOrDefaultAsync(x => x.Title == title);
    }
    
    public async Task<Problem> Update(Problem entity)
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