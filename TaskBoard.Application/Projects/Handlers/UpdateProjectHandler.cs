using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class UpdateProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<Project> Update(UpdateProjectCommand updateProjectCommand)
    {
        var projectToUpdateEntity = await _projectRepository.GetById(updateProjectCommand.Id) 
                                    ?? throw new Exception();

        projectToUpdateEntity.SetTitle(updateProjectCommand.Title);
        projectToUpdateEntity.SetDescription(updateProjectCommand.Description);
        
        return await _projectRepository.Update(projectToUpdateEntity);
    }
}