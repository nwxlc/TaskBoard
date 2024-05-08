using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Queries;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByEmailQuery getUserByEmailQuery, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(getUserByEmailQuery);

        var user = await _userRepository.TryGetByEmail(getUserByEmailQuery.Email);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        return user;
    }
}