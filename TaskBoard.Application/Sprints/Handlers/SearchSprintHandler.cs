using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class SearchSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public SearchSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint[]> SearchByTitle(string? title, int page, int pageSize)
    {
        return await _sprintRepository.SearchByTitle(title, page, pageSize);
    }
}