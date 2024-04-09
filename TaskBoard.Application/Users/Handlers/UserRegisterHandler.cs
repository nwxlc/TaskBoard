using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public UserRegisterHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(UserRegisterCommand userRegisterCommand, CancellationToken cancellationToken)
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
        return registerUser.Id;
    }
}