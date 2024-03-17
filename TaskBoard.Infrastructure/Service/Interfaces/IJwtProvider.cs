using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Service.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
}