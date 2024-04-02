using Microsoft.AspNetCore.Identity;

namespace TaskBoard.Domain.Models.Users;

public class User : IdentityUser
{
    public User(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        PasswordHash = Generate(password);
    }
    
    public ICollection<Role> Roles { get; set; }

    private string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}