using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class AddRoleToUserHandler : IRequestHandler<AddRoleToUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public AddRoleToUserHandler(IUserRepository userRepository, 
        IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var user = await _userRepository.TryGetById(request.UserId);

        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var role = await _roleRepository.TryGetById(request.RoleId);

        if (role == null)
        {
            throw new Exception("Role not founded");
        }
        
        user.AddRole(role);

        await _userRepository.Update(user);
    }
}