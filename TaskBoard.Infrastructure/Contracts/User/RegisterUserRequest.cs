namespace TaskBoard.Infrastructure.Contracts.User;

public record RegisterUserRequest(
    string Email,
    string Password,
    string UserName);