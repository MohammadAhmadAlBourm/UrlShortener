using Domain.Entities;

namespace UrlShortener.Services;

public interface IShortenedUrlRepository
{
    Task<bool> Create(ShortenedUrl shortenedUrl, CancellationToken cancellationToken);
    Task<ShortenedUrl> GetByCode(string code, CancellationToken cancellationToken);
}