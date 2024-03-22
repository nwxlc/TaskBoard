using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class CreateProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Guid> Create(CreateProjectCommand createProjectCommand)
    {
        ArgumentNullException.ThrowIfNull(createProjectCommand);

        var project = Project.Create(createProjectCommand.Title,
            createProjectCommand.Description);

        await _projectRepository.Create(project);
        return project.Id;
    }
}