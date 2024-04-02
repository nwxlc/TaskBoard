using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserLoginHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(UserLoginCommand userLoginCommand, CancellationToken cancellationToken)
    {
        var user = await _userRepository.TryGetByEmail(userLoginCommand.Email);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var result = user.Verify(userLoginCommand.Password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}