using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Authentication;

public class ConfirmTokenGenerator : IConfirmTokenGenerator
{
    private readonly JwtOptions _options;

    public ConfirmTokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims =
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(CustomClaims.UserId, user.Id.ToString())
        };

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