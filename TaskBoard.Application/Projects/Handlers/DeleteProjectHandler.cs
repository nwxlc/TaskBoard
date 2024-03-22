using TaskBoard.Application.Interfaces.Repositories;

namespace TaskBoard.Application.Projects.Handlers;

public class DeleteProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Delete(Guid id)
    {
        await _projectRepository.Delete(id);
    }
}