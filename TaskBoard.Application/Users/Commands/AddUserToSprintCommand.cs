using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class AddUserToSprintCommand : IRequest<Guid>
{
    public Guid SprintId { get; set; }

    public string UserEmail { get; set; }
}