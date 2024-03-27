using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Queries;

public class GetSprintByIdQuery : IRequest<Sprint>
{
    public Guid Id { get; set; }
}