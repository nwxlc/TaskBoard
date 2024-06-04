using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Sprints.Commands;

namespace TaskBoard.Application.Sprints.Handlers;

public class AddFileToSprintHandler : IRequestHandler<AddFileToSprintCommand, Guid>
{
    private readonly IFileRepository _fileRepository;
    private readonly ISprintRepository _sprintRepository;

    public AddFileToSprintHandler(IFileRepository fileRepository, 
        ISprintRepository sprintRepository)
    {
        _fileRepository = fileRepository;
        _sprintRepository = sprintRepository;
    }

    public async Task<Guid> Handle(AddFileToSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetById(request.SprintId);

        if (sprint == null)
        {
            throw new Exception("Sprint not founded");
        }

        var file = await _fileRepository.TryGetById(request.FileId);

        if (file == null)
        {
            throw new Exception("File not founded");
        }
        
        if (sprint.Files.Contains(file))
        {
            throw new Exception("File has already been added to sprint");
        }
        
        sprint.AddFile(file);

        return await _sprintRepository.Update(sprint);
    }
}