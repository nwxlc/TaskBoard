using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Handlers;

public class GetByIdSprintHandler : IRequestHandler<GetSprintByIdQuery, Sprint>
{
    private readonly ISprintRepository _sprintRepository;

    public GetByIdSprintHandler(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<Sprint> Handle(GetSprintByIdQuery query, CancellationToken cancellationToken)
    {
        return await _sprintRepository.GetById(query.Id);
    }
}