using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IPermissionRepository
{
    Task<Permission> TryGetById(Guid id);
}