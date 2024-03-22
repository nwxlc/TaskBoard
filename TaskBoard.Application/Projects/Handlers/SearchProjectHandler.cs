using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class SearchProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public SearchProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project[]> SearchByTitle(string? title, int page, int pageSize)
    {
        return await _projectRepository.SearchByTitle(title, page, pageSize);
    }
}