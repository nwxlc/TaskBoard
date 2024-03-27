using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Application.Sprints.Handlers;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class GetByIdProjectHandler : IRequestHandler<GetProjectByIdQuery, Project>
{
    private readonly IProjectRepository _projectRepository;

    public GetByIdProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
    {
        return await _projectRepository.GetById(query.Id);
    }
}