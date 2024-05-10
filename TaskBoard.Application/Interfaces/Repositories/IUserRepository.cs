using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> TryGetById(Guid id);
    Task<User> TryGetByEmail(string email);
    Task Create(User user);
    Task Update(User entity);
}