using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Commands;

namespace TaskBoard.Application.Problems.Handlers;

public class UpdateProblemHandler : IRequestHandler<UpdateProblemCommand, Guid>
{
    private readonly IProblemRepository _problemRepository;

    public UpdateProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Handle(UpdateProblemCommand updateProblemCommand, CancellationToken cancellationToken)
    {
        var problemToUpdateEntity = await _problemRepository.GetById(updateProblemCommand.Id);
        
        problemToUpdateEntity.SetTitle(updateProblemCommand.Title);
        problemToUpdateEntity.SetDescription(updateProblemCommand.Description);
        problemToUpdateEntity.SetComment(updateProblemCommand.Comment);
        
        return await _problemRepository.Update(problemToUpdateEntity);
    }
}