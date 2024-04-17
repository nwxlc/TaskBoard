using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserLoginHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
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

        var token = _tokenGenerator.GenerateToken(user);

        return token;
    }
}