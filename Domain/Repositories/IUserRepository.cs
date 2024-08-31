using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<bool> Create(User user, CancellationToken cancellationToken);
    Task<bool> Update(User user, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    Task<bool> IsExist(string username, CancellationToken cancellationToken);
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
}