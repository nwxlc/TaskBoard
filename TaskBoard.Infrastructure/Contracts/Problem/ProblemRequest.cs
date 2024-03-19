namespace TaskBoard.Contracts;

public record ProblemRequest(
    string Title,
    string Description,
    string Comment,
    bool Status);