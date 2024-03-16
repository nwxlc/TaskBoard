using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Infrastructure;

namespace TaskBoard.Domain.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Project entity)
    {
        await _context.Projects.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Project> GetById(Guid id)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Project> GetByTitle(string title)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Title == title);
    }
    
    public async Task<Project> Update(Project entity)
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