namespace TaskBoard.Infrastructure.Contracts.Sprint;

public record SprintRequest(
    string Title,
    string Description,
    string Comment,
    Guid ProjectId);