namespace TaskBoard.Infrastructure.Contracts.Project;

public record ProjectRequest(
    string Title,
    string Description);