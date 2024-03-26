using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class SearchByTitleSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public SearchByTitleSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint[]> SearchByTitle(SearchSprintByTitleQuery query)
    {
        return await _sprintRepository.SearchByTitle(query.Title, query.Page, query.PageSize);
    }
}