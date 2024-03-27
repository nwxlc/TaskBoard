using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Queries;

public class GetProjectByIdQuery : IRequest<Project>
{
    public Guid Id { get; set; }
}