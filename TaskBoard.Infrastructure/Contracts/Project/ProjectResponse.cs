namespace TaskBoard.Infrastructure.Contracts.Project;

public record ProjectResponse(
    Guid Id,
    string Title,
    string Description);