using TaskBoard.Application.Problems.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Interfaces.Service;

public interface IProblemService
{
    Task<Guid> Create(CreateProblemCommand createProblemCommand);
    Task<Problem> GetById(Guid id);
    Task<Problem[]> SearchByTitle(string title, int page, int pageSize); 
    Task<Guid> Update(UpdateProblemCommand updateProblemCommand);
    Task Delete(Guid id);
}
