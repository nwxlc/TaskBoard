using TaskBoard.Domain.Models;

namespace TaskBoard.Domain.Interfaces;

public interface ISprintRepository
{
    Task Create(Sprint entity);
    Task<Sprint> GetById(Guid id);
    Task<Sprint> GetByTitle(string title);
    Task<Sprint> Update(Sprint entity);
    Task Delete(Guid id);
}