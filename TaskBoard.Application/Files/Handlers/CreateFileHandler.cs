using MediatR;
using TaskBoard.Application.Files.Commands;
using TaskBoard.Application.Interfaces.Repositories;
using File = TaskBoard.Domain.Models.File;

namespace TaskBoard.Application.Files.Handlers;

public class CreateFileHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IFileRepository _fileRepository;

    public CreateFileHandler(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var file = File.Create(request.Id,
            request.Name,
            request.Path);

        await _fileRepository.Create(file);
        return file.Id;
    }
}