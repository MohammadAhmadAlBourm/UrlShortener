using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UrlShortener.Services;

internal sealed class UserRepository(
    ApplicationDbContext _context,
    ILogger<UserRepository> _logger) : IUserRepository
{
    public async Task<Result<bool>> Create(User user, CancellationToken cancellationToken)
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

    public async Task<Result<bool>> Delete(Guid id, CancellationToken cancellationToken)
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

    public async Task<Result<bool>> Update(User user, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.Users
                .Where(x => x.Id == user.Id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(x => x.Name, user.Name)
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