using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class GetByIdProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public GetByIdProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> GetById(Guid id)
    {
        return await _projectRepository.GetById(id);
    }
}