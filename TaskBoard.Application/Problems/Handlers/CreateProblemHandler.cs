using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class CreateProblemHandler 
{
    private readonly IProblemRepository _problemRepository;

    private CreateProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }
    
    public async Task<Guid> Create(CreateProblemCommand createProblemCommand)
    {
        ArgumentNullException.ThrowIfNull(createProblemCommand);

        var problem = Problem.Create(createProblemCommand.Title, 
            createProblemCommand.Description,
            createProblemCommand.Comment);
        
        await _problemRepository.Create(problem);
        return problem.Id;
    }
}