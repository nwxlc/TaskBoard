namespace TaskBoard.Infrastructure.Contracts.Problem;

public record ProblemRequest(
    string Title,
    string Description,
    string Comment,
    Guid SprintId);