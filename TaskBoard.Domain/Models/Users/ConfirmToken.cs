namespace TaskBoard.Domain.Models.Users;

public class ConfirmToken
{
    public ConfirmToken(Guid id, string token)
    {
        Id = Id;
        Token = token;
    }

    public Guid Id { get; set; }

    public string Token { get; set; }
}