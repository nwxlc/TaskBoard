using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Commands;

namespace TaskBoard.Application.Projects.Handlers;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<Guid> Handle(UpdateProjectCommand updateProjectCommand, CancellationToken cancellationToken)
    {
        var projectToUpdateEntity = await _projectRepository.GetById(updateProjectCommand.Id) 
                                    ?? throw new Exception();

        projectToUpdateEntity.SetTitle(updateProjectCommand.Title);
        projectToUpdateEntity.SetDescription(updateProjectCommand.Description);
        
        return await _projectRepository.Update(projectToUpdateEntity);
    }
}