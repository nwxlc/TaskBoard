using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces;

public interface ISprintRepository
{
    Task Create(SprintEntity entity);
    Task<SprintEntity> GetById(Guid id);
    Task<SprintEntity> GetByTitle(string title);
    Task<SprintEntity> Update(SprintEntity entity);
    Task Delete(Guid id);
}