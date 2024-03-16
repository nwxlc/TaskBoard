using TaskBoard.Domain.Models;

namespace TaskBoard.Domain.Interfaces;

public interface IProjectRepository
{
    Task Create(Project entity);
    Task<Project> GetById(Guid id);
    Task<Project> GetByTitle(string title);
    Task<Project> Update(Project entity);
    Task Delete(Guid id);
}