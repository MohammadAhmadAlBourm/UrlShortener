using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : IUserRepository
{

    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<UserRepository> _logger = logger;

    public async Task<bool> Create(User user, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Users.AddAsync(user, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.Users
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return count > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> IsExist(string username, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users.AnyAsync(x => x.Username == username, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(User user, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.Users
                .Where(x => x.Id == user.Id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(x => x.FirstName, user.FirstName)
                    .SetProperty(x => x.LastName, user.LastName)
                    .SetProperty(x => x.MiddleName, user.MiddleName)
                    .SetProperty(x => x.Roles, user.Roles)
                    .SetProperty(x => x.UpdatedDate, DateTime.Now), cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}