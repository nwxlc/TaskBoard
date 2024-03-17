using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> TryGetByEmail(string email);
    Task Create(User user);
}