using File = TaskBoard.Domain.Models.File;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IFileRepository
{
    Task<Guid> Create(File entity);

    Task<File> TryGetById(Guid id);
}