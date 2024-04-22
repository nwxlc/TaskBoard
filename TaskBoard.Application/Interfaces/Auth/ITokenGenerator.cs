using TaskBoard.Application.Users.Commands;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Auth;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}