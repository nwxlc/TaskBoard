using MediatR;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class SendEmailHandler : IRequestHandler<SendEmailCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfirmTokenGenerator _tokenGenerator;

    public SendEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<string> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.TryGetByEmail(request.Email);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var isBlocked = user.IsBlocked;

        if (isBlocked)
        {
            throw new Exception("User is blocked");
        }

        var token = _tokenGenerator.GenerateToken(user);

        return token;
    }
}