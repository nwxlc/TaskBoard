using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain.Repositories;

public class SprintRepository : ISprintRepository
{
    private readonly AppDbContext _context;

    public SprintRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(SprintEntity entity)
    {
        await _context.Sprints.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<SprintEntity> GetById(Guid id)
    {
        return await _context.Sprints.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<SprintEntity> GetByTitle(string title)
    {
        return await _context.Sprints.FirstOrDefaultAsync(x => x.Title == title);
    }
    
    public async Task<SprintEntity> Update(SprintEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Guid id)
    {
        var sprintToDelete = await _context.Sprints.FirstOrDefaultAsync(x => x.Id == id);
        if (sprintToDelete != null)
        {
            _context.Sprints.Remove(sprintToDelete);
            await _context.SaveChangesAsync();
        }
    }
}