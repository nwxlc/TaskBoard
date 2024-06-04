using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Commands;

namespace TaskBoard.Application.Problems.Handlers;

public class AddFileToProblemHandler : IRequestHandler<AddFileToProblemCommand, Guid>
{
    private readonly IFileRepository _fileRepository;
    private readonly IProblemRepository _problemRepository;

    public AddFileToProblemHandler(IFileRepository fileRepository, 
        IProblemRepository problemRepository)
    {
        _fileRepository = fileRepository;
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Handle(AddFileToProblemCommand request, CancellationToken cancellationToken)
    {
        var problem = await _problemRepository.GetById(request.ProblemId);

        if (problem == null)
        {
            throw new Exception("Problem not founded");
        }

        var file = await _fileRepository.TryGetById(request.FileId);

        if (file == null)
        {
            throw new Exception("File not founded");
        }
        
        if (problem.Files.Contains(file))
        {
            throw new Exception("File has already been added to problem");
        }
        
        problem.AddFile(file);

        return await _problemRepository.Update(problem);
    }
}