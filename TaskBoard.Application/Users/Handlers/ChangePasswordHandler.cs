using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public ChangePasswordHandler(IUserRepository userRepository, 
        ITokenRepository tokenRepository)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<Guid> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
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
        
        
    }
}