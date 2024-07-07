using Domain.Entities;

namespace UrlShortener.Services;

public interface IAuthenticationRepository
{
    string GenerateToken(User user);
}