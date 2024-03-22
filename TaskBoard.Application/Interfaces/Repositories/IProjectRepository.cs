using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IProjectRepository
{
    Task Create(Project entity);
    Task<Project> GetById(Guid id);
    Task<Project[]> SearchByTitle(string? title, int page, int pageSize);
    Task<Project> Update(Project entity);
    Task Delete(Guid id);
}