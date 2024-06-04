using MediatR;

namespace TaskBoard.Application.Files.Commands;

public class CreateFileCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Path { get; set; }
}