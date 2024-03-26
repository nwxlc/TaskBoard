using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Application.Sprints.Handlers;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class GetByIdProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public GetByIdProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> GetById(GetProjectByIdQuery query)
    {
        return await _projectRepository.GetById(query.Id);
    }
}