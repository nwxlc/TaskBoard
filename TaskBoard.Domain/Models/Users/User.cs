using Microsoft.AspNetCore.Identity;

namespace TaskBoard.Domain.Models.Users;

public class User : IdentityUser
{
    public User(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
}