using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<Role> TryGetById(Guid id);
}