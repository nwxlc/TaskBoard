using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class AddPermissionToUserHandler : IRequestHandler<AddPermissionToUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;

    public AddPermissionToUserHandler(IUserRepository userRepository, 
        IPermissionRepository permissionRepository)
    {
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
    }

    public async Task Handle(AddPermissionToUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var user = await _userRepository.TryGetById(request.UserId);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var permission = await _permissionRepository.TryGetById(request.PermissionId);

        if (permission == null)
        {
            throw new Exception("Permission not founded");
        }
        
        user.AddPermission(permission);

        await _userRepository.Update(user);
    }
}