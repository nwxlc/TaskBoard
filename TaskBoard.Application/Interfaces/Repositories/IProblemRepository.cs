using TaskBoard.Domain.Models;

namespace TaskBoard.Domain.Interfaces;

public interface IProblemRepository
{
    Task Create(Problem entity);
    Task<Problem> GetById(Guid id);
    Task<Problem> GetByTitle(string title);
    Task<Problem> Update(Problem entity);
    Task Delete(Guid id);
}	