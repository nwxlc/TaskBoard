using TaskBoard.Application.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Service;

public interface IProblemService
{
    Task<Guid> Create(ProblemCommand problemCommand);
    Task<Problem> GetById(Guid id);
    Task<Problem> GetByTitle(string title); 
    Task<Problem> Update(Guid id, string title, string description, string comment, bool status);
    Task Delete(Guid id);
}
