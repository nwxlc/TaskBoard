using MediatR;

namespace TaskBoard.Application.Problems.Commands;

public class CreateProblemCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public Guid SprintId { get; set; }
}