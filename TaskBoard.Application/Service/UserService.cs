namespace TaskBoard.Application.Service;

public class UserService
{
    /*private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    
    public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
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

    public async Task<string> Login(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);

        var result = _passwordHasher.Verify(password, user.PasswordHash);

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }*/
}