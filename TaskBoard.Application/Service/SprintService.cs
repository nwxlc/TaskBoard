using TaskBoard.Application.Commands;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Service;

public class SprintService : ISprintService
{
    private readonly ISprintRepository _sprintRepository;

    public SprintService(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Guid> Create(SprintCommand sprintCommand)
    {
        ArgumentNullException.ThrowIfNull(sprintCommand);
        
        var sprint = new Sprint(
            sprintCommand.Id, 
            DateTime.Now,
            sprintCommand.Title, 
            sprintCommand.Description, 
            sprintCommand.Comment
        );

        await _sprintRepository.Create(sprint);
        return sprint.Id;
    }
    
    public async Task<Sprint> GetById(Guid id)
    {
        return await _sprintRepository.GetById(id);
    }

    public async Task<Sprint> GetByTitle(string title)
    {
        return await _sprintRepository.GetByTitle(title);
    }
    
    public async Task<Sprint> Update(Guid id, string title, string description, string comment)
    {
        var sprintToUpdateEntity = await _sprintRepository.GetById(id) 
                                    ?? throw new Exception();

        sprintToUpdateEntity.Title = title;
        sprintToUpdateEntity.Description = description;
        sprintToUpdateEntity.Comment = comment;
        
        return await _sprintRepository.Update(sprintToUpdateEntity);
    }

    public async Task Delete(Guid id)
    {
        await _sprintRepository.Delete(id);
    }
}