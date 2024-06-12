using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, (Guid userId, string tokenResponse)>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserRegisterHandler(IUserRepository userRepository, 
        ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<(Guid userId, string tokenResponse)> Handle(UserRegisterCommand userRegisterCommand, CancellationToken cancellationToken)
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

        var response = (userId: registerUser.Id, tokenResponse: token);
        
        return response;
    }
}