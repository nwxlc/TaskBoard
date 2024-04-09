using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class CreateProblemHandler : IRequestHandler<CreateProblemCommand, Guid>
{
    private readonly IProblemRepository _problemRepository;

    public CreateProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }
    
    public async Task<Guid> Handle(CreateProblemCommand createProblemCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createProblemCommand);

        var problem = Problem.Create(createProblemCommand.Title, 
            createProblemCommand.Description,
            createProblemCommand.Comment);
        
        await _problemRepository.Create(problem);
        return problem.Id;
    }
}