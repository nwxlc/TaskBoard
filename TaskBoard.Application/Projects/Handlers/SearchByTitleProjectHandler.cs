using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Handlers;

public class SearchByTitleProjectHandler : IRequestHandler<SearchProjectByTitleQuery, Project[]>
{
    private readonly IProjectRepository _projectRepository;

    public SearchByTitleProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project[]> Handle(SearchProjectByTitleQuery query, CancellationToken cancellationToken)
    {
        return await _projectRepository.SearchByTitle(query.Title, query.Page, query.PageSize);
    }
}