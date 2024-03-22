using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class CreateSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public CreateSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }
    
    public async Task<Guid> Create(CreateSprintCommand createSprintCommand)
    {
        ArgumentNullException.ThrowIfNull(createSprintCommand);

        var sprint = Sprint.Create(createSprintCommand.Title,
            createSprintCommand.Description,
            createSprintCommand.Comment);

        await _sprintRepository.Create(sprint);
        return sprint.Id;
    }
}