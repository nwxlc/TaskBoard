using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(ProjectEntity entity)
    {
        await _context.Projects.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<ProjectEntity> GetById(Guid id)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ProjectEntity> GetByTitle(string title)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Title == title);
    }
    
    public async Task<ProjectEntity> Update(ProjectEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Guid id)
    {
        var projectToDelete = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        if (projectToDelete != null)
        {
            _context.Projects.Remove(projectToDelete);
            await _context.SaveChangesAsync();
        }
    }
}