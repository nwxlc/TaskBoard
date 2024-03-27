using MediatR;

namespace TaskBoard.Application.Problems.Commands;

public class UpdateProblemCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
}