using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IProblemRepository
{
    Task<Guid> Create(Problem entity);
    Task<Problem> GetById(Guid id);
    Task<Problem> GetByTitle(string title);
    Task<Guid> Update(Problem entity);
    Task Delete(Guid id);
}	