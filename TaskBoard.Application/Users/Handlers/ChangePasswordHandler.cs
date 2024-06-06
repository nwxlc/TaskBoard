using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Users.Handlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public ChangePasswordHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
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

        user.ChangePassword(request.Password, request.Token);

        await _userRepository.Update(user);

        return user.Id;
    }
}