using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Service;

public interface IProblemService
{
    Task Create(Problem model);
    Task<Problem> GetById(Guid id);
    Task<Problem> GetByTitle(string title); 
    Task<Problem> Update(Guid id, string title, string description, string comment, bool status);
    Task Delete(Guid id);
}
