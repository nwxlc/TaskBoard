using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Commands;

namespace TaskBoard.Application.Problems.Handlers;

public class DeleteProblemHandler : IRequestHandler<DeleteProblemCommand>
{
    private readonly IProblemRepository _problemRepository;

    public DeleteProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }
    
    public async Task Handle(DeleteProblemCommand deleteProblemCommand, CancellationToken cancellationToken)
    {
        await _problemRepository.Delete(deleteProblemCommand.Id);
    }
}