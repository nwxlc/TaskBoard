using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces;

public interface IProblemRepository
{
    Task Create(ProblemEntity entity);
    Task<ProblemEntity> GetById(Guid id);
    Task<ProblemEntity> GetByTitle(string title);
    Task<ProblemEntity> Update(ProblemEntity entity);
    Task Delete(Guid id);
}