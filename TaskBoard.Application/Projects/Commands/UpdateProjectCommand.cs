using MediatR;

namespace TaskBoard.Application.Projects.Commands;

public class UpdateProjectCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}