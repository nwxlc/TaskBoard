using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Repositories;

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

    public async Task<Project[]> GetByTitle(string? title, int page, int pageSize)
    {
        var projects = _context.Projects.AsQueryable();
        if (title != null)
        {
            projects = projects
                .Where(x => EF.Functions.ILike(x.Title, $"%{title}%"));
        }
        
        return await projects.OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToArrayAsync();
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