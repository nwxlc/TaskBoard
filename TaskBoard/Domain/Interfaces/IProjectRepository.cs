using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces;

public interface IProjectRepository
{
    Task Create(ProjectEntity entity);
    Task<ProjectEntity> GetById(Guid id);
    Task<ProjectEntity> GetByTitle(string title);
    Task<ProjectEntity> Update(ProjectEntity entity);
    Task Delete(Guid id);
}