using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Auth;

public interface IConfirmTokenGenerator
{
    string GenerateToken(User user);
}