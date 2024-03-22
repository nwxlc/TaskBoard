using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface ISprintRepository
{
    Task<Guid> Create(Sprint entity);
    Task<Sprint> GetById(Guid id);
    Task<Sprint[]> SearchByTitle(string? title, int page, int pageSize);
    Task<Guid> Update(Sprint entity);
    Task Delete(Guid id);
}