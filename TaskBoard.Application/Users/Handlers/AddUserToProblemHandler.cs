using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Commands;

namespace TaskBoard.Application.Users.Handlers;

public class AddUserToProblemHandler : IRequestHandler<AddUserToProblemCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly ISprintRepository _sprintRepository;
    private readonly IProblemRepository _problemRepository;

    public AddUserToProblemHandler(IUserRepository userRepository, 
        ISprintRepository sprintRepository, 
        IProblemRepository problemRepository)
    {
        _userRepository = userRepository;
        _sprintRepository = sprintRepository;
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Handle(AddUserToProblemCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.TryGetByEmail(request.UserEmail).Result;
        
        if (user == null)
        {
            throw new Exception("User not founded");
        }
        
        var problem = _problemRepository.GetById(request.ProblemId).Result;

        if (problem == null)
        {
            throw new Exception("Problem not founded");
        }
        
        var sprint = _sprintRepository.GetById(problem.SprintId).Result;

        if (sprint == null)
        {
            throw new Exception("Sprint not founded");
        }

        if (!sprint.SprintUsers.Contains(user))
        {
            throw new Exception("The user has not been added to the project");
        }
        
        problem.AddUser(user);

        return await _problemRepository.Update(problem);
    }
}