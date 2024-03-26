using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class GetByIdSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public GetByIdSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint> GetById(GetSprintByIdQuery query)
    {
        return await _sprintRepository.GetById(query.Id);
    }
}