using Domain.Abstractions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<Result<bool>> Create(User user, CancellationToken cancellationToken);
    Task<Result<bool>> Update(User user, CancellationToken cancellationToken);
    Task<bool> IsExist(string username, CancellationToken cancellationToken);
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
}