using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class AddUserToProjectHandler : IRequestHandler<AddUserToProjectCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;

    public AddUserToProjectHandler(IUserRepository userRepository, 
        IProjectRepository projectRepository)
    {
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Guid> Handle(AddUserToProjectCommand addUserToProjectCommand, CancellationToken cancellationToken)
    {
        var user = await _userRepository.TryGetByEmail(addUserToProjectCommand.UserEmail);
        
        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var project = await _projectRepository.GetById(addUserToProjectCommand.ProjectId);

        if (project == null)
        {
            throw new Exception("Project not founded");
        }
        
        project.AddUser(user);

        return await _projectRepository.Update(project);
    }
}