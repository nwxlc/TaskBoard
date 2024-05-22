using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;

namespace TaskBoard.Application.Sprints.Handlers;

public class AddUserToSprintHandler : IRequestHandler<AddUserToSprintCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly ISprintRepository _sprintRepository;
    private readonly IProjectRepository _projectRepository;

    public AddUserToSprintHandler(IUserRepository userRepository, 
        ISprintRepository sprintRepository, 
        IProjectRepository projectRepository)
    {
        _userRepository = userRepository;
        _sprintRepository = sprintRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Guid> Handle(AddUserToSprintCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.TryGetByEmail(request.UserEmail);
        
        if (user == null)
        {
            throw new Exception("User not founded");
        }
        
        var sprint = await _sprintRepository.GetById(request.SprintId);

        if (sprint == null)
        {
            throw new Exception("Sprint not founded");
        }

        var project = await _projectRepository.GetById(sprint.ProjectId);

        if (project == null)
        {
            throw new Exception("Project not founded");
        }

        if (!project.ProjectUsers.Contains(user))
        {
            throw new Exception("The user has not been added to the sprint");
        }
        
        sprint.AddUser(user);

        return await _sprintRepository.Update(sprint);
    }
}