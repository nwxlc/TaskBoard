using MediatR;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Queries;

public class GetUserByIdQuery : IRequest<User>
{
    public Guid Id { get; set; }
}