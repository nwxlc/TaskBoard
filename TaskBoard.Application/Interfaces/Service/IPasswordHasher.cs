namespace TaskBoard.Application.Interfaces.Service;

public interface IPasswordHasher
{
    string Generate(string password);

    bool Verify(string password, string hashedPassword);
}