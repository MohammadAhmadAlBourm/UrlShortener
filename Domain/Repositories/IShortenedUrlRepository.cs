using Domain.Entities;

namespace Domain.Repositories;

public interface IShortenedUrlRepository
{
    Task<bool> Create(ShortenedUrl shortenedUrl, CancellationToken cancellationToken);
    Task<ShortenedUrl> GetByCode(string code, CancellationToken cancellationToken);

    Task DeleteUnnecessaryUrls(CancellationToken cancellationToken);
}