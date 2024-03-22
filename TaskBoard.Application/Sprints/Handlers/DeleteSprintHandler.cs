using TaskBoard.Application.Interfaces.Repositories;

namespace TaskBoard.Application.Sprints.Handlers;

public class DeleteSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public DeleteSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }
    
    public async Task Delete(Guid id)
    {
        await _sprintRepository.Delete(id);
    }
}