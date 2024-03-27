using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Commands;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Guid> Handle(CreateProjectCommand createProjectCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createProjectCommand);

        var project = Project.Create(createProjectCommand.Title,
            createProjectCommand.Description);

        await _projectRepository.Create(project);
        return project.Id;
    }
}