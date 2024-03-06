using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Models;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Service.Implementations;

public class UserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    
    public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task Register(string userName, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var userEntity = new UserEntity()
        {
            UserName = userName,
            Email = email,
            PasswordHash = hashedPassword
        };

        await _userRepository.Create(userEntity);
    }
}