using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class SearchByTitleProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public SearchByTitleProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Problem[]> SearchByTitle(SearchProblemByTitleQuery query)
    {
        return await _problemRepository.SearchByTitle(query.Title, query.Page, query.PageSize);
    }
}