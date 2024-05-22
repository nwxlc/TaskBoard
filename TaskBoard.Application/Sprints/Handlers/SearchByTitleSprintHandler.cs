using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class SearchByTitleSprintHandler : IRequestHandler<SearchSprintByTitleQuery, Sprint[]>
{
    private readonly ISprintRepository _sprintRepository;

    public SearchByTitleSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint[]> Handle(SearchSprintByTitleQuery query, CancellationToken cancellationToken)
    {
        return await _sprintRepository.SearchByTitle(query.Title, query.Page, query.PageSize);
    }
}