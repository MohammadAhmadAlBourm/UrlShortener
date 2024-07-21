
using Domain.Entities;
using Domain.Options;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UrlShortener.Services;

internal sealed class AuthenticationRepository(IOptions<JwtOptions> _options) : IAuthenticationRepository
{
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Value.SecretKey);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = CreateClaims(user),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescription);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity CreateClaims(User user)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

        foreach (var role in user.Roles)
        {
            claims.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
        }

        return claims;
    }
}