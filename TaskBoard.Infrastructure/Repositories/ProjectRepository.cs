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

    public async Task<Guid> Create(Project entity)
    {
        await _context.Projects.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
    
    public async Task<Project> GetById(Guid id)
    {
        return await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new ArgumentException("Project not found");
    }

    public async Task<Project[]> SearchByTitle(string? title, int page, int pageSize)
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
    
    public async Task<Guid> Update(Project entity)
    {
        _context.Projects.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var countDeletedRows = await _context.Projects.Where(x => x.Id == id).ExecuteDeleteAsync();
        if (countDeletedRows == 0)
        {
            throw new ArgumentException("Project not found");
        }
    }
}