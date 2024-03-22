using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;

namespace TaskBoard.Application.Sprints.Handlers;

public class UpdateSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public UpdateSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }
    
    public async Task<Guid> Update(UpdateSprintCommand updateSprintCommand)
    {
        var sprintToUpdateEntity = await _sprintRepository.GetById(updateSprintCommand.Id) 
                                    ?? throw new Exception();

        sprintToUpdateEntity.SetTitle(updateSprintCommand.Title);
        sprintToUpdateEntity.SetDescription(updateSprintCommand.Description);
        sprintToUpdateEntity.SetComment(updateSprintCommand.Comment);
        
        return await _sprintRepository.Update(sprintToUpdateEntity);
    }
}