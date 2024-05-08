using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class CreateSprintHandler : IRequestHandler<CreateSprintCommand, Guid>
{
    private readonly ISprintRepository _sprintRepository;

    public CreateSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }
    
    public async Task<Guid> Handle(CreateSprintCommand createSprintCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createSprintCommand);

        var sprint = Sprint.Create(createSprintCommand.Title,
            createSprintCommand.Description,
            createSprintCommand.Comment,
            createSprintCommand.ProjectId);

        await _sprintRepository.Create(sprint);
        return sprint.Id;
    }
}