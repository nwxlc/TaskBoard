using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
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

    public async Task<Guid> Create(Problem entity)
    {
        await _context.Problems.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<List<Problem>> GetByTitle(string title)
    {
        var problemsEntities = await _context.Problems.ToList();

        return problemsEntities;
    }
    
    public async Task<Problem> GetById(Guid id)
    {
        return await _context.Problems
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("Problem not found");
    }

    public async Task<Problem> GetByTitle(string title)
    {
        return await _context.Problems
                   .FirstOrDefaultAsync(x => x.Title == title)
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
        
        /*var problemToDelete = await _context.Problems.FirstOrDefaultAsync(x => x.Id == id);
        if (problemToDelete != null)
        {
            _context.Problems.Remove(problemToDelete);
            await _context.SaveChangesAsync();
        }*/
        
        //упасть если нет объекта
        //ExecuteDeleteAsync
    }
}