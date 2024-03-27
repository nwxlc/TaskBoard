using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;

namespace TaskBoard.Application.Sprints.Handlers;

public class DeleteSprintHandler : IRequestHandler<DeleteSprintCommand>
{
    private readonly ISprintRepository _sprintRepository;

    public DeleteSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task Handle(DeleteSprintCommand deleteSprintCommand, CancellationToken cancellationToken)
    {
        await _sprintRepository.Delete(deleteSprintCommand.Id);
    }
    
}