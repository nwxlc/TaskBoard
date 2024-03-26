using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class SearchByTitleProjectHandler
{
    private readonly IProjectRepository _projectRepository;

    public SearchByTitleProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project[]> SearchByTitle(SearchSprintByTitleQuery query)
    {
        return await _projectRepository.SearchByTitle(query.Title, query.Page, query.PageSize);
    }
}