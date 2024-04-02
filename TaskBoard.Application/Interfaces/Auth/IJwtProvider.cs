using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}