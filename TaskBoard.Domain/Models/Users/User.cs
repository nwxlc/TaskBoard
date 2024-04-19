namespace TaskBoard.Domain.Models.Users;

public class User 
{
    private User(Guid id,string userName, string email, string passwordHash)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }
    
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    
    public static User Create(string userName, string email, string password)
    {
        var passwordHash = Generate(password);

        var user = new User(Guid.NewGuid(), userName, email, passwordHash);

        return user;
    }

    private static string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}