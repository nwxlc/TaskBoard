namespace TaskBoard.Infrastructure.Contracts;

public record RegisterUserRequest(
    string Email,
    string Password,
    string UserName);