using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Authentication;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtOptions _options;

    public TokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims = user.Roles
            // .SelectMany(x => x.Permissions, (_, permission) => new Claim(ClaimTypes.Role, permission.Name))
            .SelectMany(x => x.Permissions, (_, permission) => new Claim("permission", permission.Name))
            .Union(new[] { new Claim(CustomClaims.UserId, user.Id.ToString()) })
            .ToArray();
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpireHours));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}