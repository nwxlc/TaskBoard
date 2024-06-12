using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, (Guid userId, string tokenResponse)>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserLoginHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<(Guid userId, string tokenResponse)> Handle(UserLoginCommand userLoginCommand, CancellationToken cancellationToken)
    {
        var user = await _userRepository.TryGetByEmail(userLoginCommand.Email);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var isBlocked = user.IsBlocked;

        if (isBlocked)
        {
            throw new Exception("User is blocked");
        }

        var verifyResult = user.Verify(userLoginCommand.Password, user.PasswordHash);

        if (verifyResult == false)
        {
            throw new Exception("Failed to login");
        }

        var token = _tokenGenerator.GenerateToken(user);

        var result = (userId: user.Id, tokenResponse: token);
        
        return result;
    }
}