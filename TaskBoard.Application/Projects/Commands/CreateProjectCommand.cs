using MediatR;

namespace TaskBoard.Application.Projects.Commands;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
}