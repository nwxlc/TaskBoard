using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class GetByIdSprintHandler
{
    private readonly ISprintRepository _sprintRepository;

    public GetByIdSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint> GetById(Guid id)
    {
        return await _sprintRepository.GetById(id);
    }
}