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

    public async Task DeleteUnnecessaryUrls(CancellationToken cancellationToken)
    {
        try
        {
            // Define the cutoff date as one year ago from now
            var cutOffDate = DateTime.Now.AddYears(-1);

            var urlsToDelete = await _context.ShortenedUrls
                .Where(url => url.CreatedDate < cutOffDate)
                .ToListAsync(cancellationToken);

            if (urlsToDelete.Count != 0)
            {
                _context.ShortenedUrls.RemoveRange(urlsToDelete);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<ShortenedUrl> GetByCode(string code, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.ShortenedUrls.FirstOrDefaultAsync(x => x.Code == code, cancellationToken)
                ?? throw new Exception("Was not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}