using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Queries;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByIdQuery getUserByEmailQuery, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(getUserByEmailQuery);

        var user = await _userRepository.TryGetById(getUserByEmailQuery.Id);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        return user;
    }
}
    
