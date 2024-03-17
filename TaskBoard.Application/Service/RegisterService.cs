using TaskBoard.Application.Commands.Users;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Service;

public class RegisterService
{
    private readonly IUserRepository _userRepository;

    public RegisterService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Register(UserRegisterCommand userRegisterCommand)
    {
        //var hashedPassword = _passwordHasher.Generate(password);

        ArgumentNullException.ThrowIfNull(userRegisterCommand);
        
        var checkEmailUser = _userRepository.TryGetByEmail(userRegisterCommand.Email);

        if (checkEmailUser != null)
        {
            throw new Exception("email занят");
        }

        var registerUser = new User(
            userRegisterCommand.UserName, 
            userRegisterCommand.Email,
            userRegisterCommand.Password);

        await _userRepository.Create(registerUser);
        return registerUser.Id;
    }
}