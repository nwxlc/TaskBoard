using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserRegisterHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Handle(UserRegisterCommand userRegisterCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(userRegisterCommand);
        
        var checkEmailUser = await _userRepository.TryGetByEmail(userRegisterCommand.Email);

        if (checkEmailUser != null) 
        {
             throw new Exception("email занят");
        }

        var registerUser = User.Create(
            userRegisterCommand.UserName, 
            userRegisterCommand.Email,
            userRegisterCommand.Password);

        await _userRepository.Create(registerUser);
       
        var token = _tokenGenerator.GenerateToken(registerUser);
        
        return token;
    }
}