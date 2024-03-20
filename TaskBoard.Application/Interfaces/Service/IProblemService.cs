using TaskBoard.Application.Commands.Problem;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Service;

public interface IProblemService
{
    Task<Guid> Create(CreateProblemCommand createProblemCommand);
    Task<Problem> GetById(Guid id);
    Task<Problem> GetByTitle(string title); 
    Task<Guid> Update(Guid id, string title, string description, string comment, bool status);
    Task Delete(Guid id);
}
