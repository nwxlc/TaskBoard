using TaskBoard.Application.Commands;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Service;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<Guid> Create(ProjectCommand projectCommand)
    {
        ArgumentNullException.ThrowIfNull(projectCommand);
        
        var project = new Project(
            projectCommand.Id, 
            projectCommand.Title, 
            projectCommand.Description
        );

        await _projectRepository.Create(project);
        return project.Id;
    }
    
    public async Task<Project> GetById(Guid id)
    {
        return await _projectRepository.GetById(id);
    }

    public async Task<Project> GetByTitle(string title)
    {
        return await _projectRepository.GetByTitle(title);
    }
    
    public async Task<Project> Update(Guid id, string title, string description)
    {
        var projectToUpdateEntity = await _projectRepository.GetById(id) 
                                    ?? throw new Exception();

        projectToUpdateEntity.Title = title;
        projectToUpdateEntity.Description = description;
        
        return await _projectRepository.Update(projectToUpdateEntity);
    }

    public async Task Delete(Guid id)
    {
        await _projectRepository.Delete(id);
    }
}