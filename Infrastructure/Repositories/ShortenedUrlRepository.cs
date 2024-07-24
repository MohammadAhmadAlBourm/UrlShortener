using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UrlShortener.Services;

internal sealed class ShortenedUrlRepository(
    ApplicationDbContext _context,
    ILogger<ShortenedUrlRepository> _logger
    ) : IShortenedUrlRepository
{
    public async Task<bool> Create(ShortenedUrl shortenedUrl, CancellationToken cancellationToken)
    {
        try
        {
            shortenedUrl.CreatedDate = DateTime.Now;

            await _context.ShortenedUrls.AddAsync(shortenedUrl, cancellationToken);
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
            await _context.ShortenedUrls
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task DeleteUnnecessaryUrls(CancellationToken cancellationToken)
    {
        try
        {
            await _context.ShortenedUrls
               .Where(url => url.CreatedDate < DateTime.Now.AddYears(-1))
               .ExecuteDeleteAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<ShortenedUrl?> GetByCode(string code, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.ShortenedUrls
                .FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
    public async Task<ShortenedUrl?> GetById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.ShortenedUrls
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<ShortenedUrl>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.ShortenedUrls
                 .Where(x => x.UserId == userId)
                 .AsNoTracking()
                 .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<ShortenedUrl>> GetShortenedUrls(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.ShortenedUrls
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}