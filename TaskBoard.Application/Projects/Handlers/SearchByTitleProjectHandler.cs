using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class SearchByTitleProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public SearchByTitleProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project[]> SearchByTitle(string? title, int page, int pageSize)
    {
        return await _projectRepository.SearchByTitle(title, page, pageSize);
    }
}