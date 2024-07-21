using Domain.Entities;

namespace Domain.Repositories;

public interface IAuthenticationRepository
{
    string GenerateToken(User user);
}