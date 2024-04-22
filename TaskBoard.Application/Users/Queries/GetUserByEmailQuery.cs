using MediatR;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Queries;

public class GetUserByEmailQuery : IRequest<User>
{
    public string Email { get; set; }
}