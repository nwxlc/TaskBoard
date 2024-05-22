using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class BlockUserHandler : IRequestHandler<BlockUserCommand>
{
    private readonly IUserRepository _userRepository;

    public BlockUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(BlockUserCommand blockUserCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(blockUserCommand);

        var user = await _userRepository.TryGetById(blockUserCommand.Id);

        if (user == null)
        {
            throw new Exception("User not founded");
        }
        
        user.Block();

        await _userRepository.Update(user);
    }
}