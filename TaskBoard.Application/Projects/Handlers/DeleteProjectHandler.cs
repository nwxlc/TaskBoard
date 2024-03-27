using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Handlers;
using TaskBoard.Application.Projects.Commands;

namespace TaskBoard.Application.Projects.Handlers;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Handle(DeleteProjectCommand deleteProjectCommand, CancellationToken cancellationToken)
    {
        await _projectRepository.Delete(deleteProjectCommand.Id);
    }
}