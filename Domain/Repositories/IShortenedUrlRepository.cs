using Domain.Entities;

namespace Domain.Repositories;

public interface IShortenedUrlRepository
{
    Task<bool> Create(ShortenedUrl shortenedUrl, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    Task<ShortenedUrl?> GetByCode(string code, CancellationToken cancellationToken);
    Task<ShortenedUrl?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ShortenedUrl>> GetShortenedUrls(CancellationToken cancellationToken);
    Task DeleteUnnecessaryUrls(CancellationToken cancellationToken);
    Task<IEnumerable<ShortenedUrl>> GetByUserId(Guid userId, CancellationToken cancellationToken);
}