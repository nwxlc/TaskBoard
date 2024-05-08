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

    public async Task<Guid> Handle(AddUserToProjectCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.TryGetByEmail(request.UserEmail).Result;
        
        if (user == null)
        {
            throw new Exception("User not founded");
        }

        var project = _projectRepository.GetById(request.ProjectId).Result;

        if (project == null)
        {
            throw new Exception("Project not founded");
        }
        
        project.AddUser(user);

        return await _projectRepository.Update(project);
    }
}