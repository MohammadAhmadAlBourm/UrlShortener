using Application.Abstractions.Authentication;
using Domain.Entities;
using Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication;

internal sealed class TokenProvider : ITokenProvider
{
    private readonly JwtOptions _options;

    public TokenProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Create(User user)
    {
        string secretKey = _options.Secret;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationInMinutes),
            SigningCredentials = credentials,
            Issuer = _options.Issuer,
            Audience = _options.Audience,
        };

        var handler = new JsonWebTokenHandler();

        string token = handler.CreateToken(tokenDescriptor);

        return token;
    }
}
