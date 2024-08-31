using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal sealed class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly ILogger _logger;
    private readonly ApplicationDbContext _context;

    public UnitOfWork(
        ILoggerFactory logger,
        ApplicationDbContext context,
        ShortenedUrlRepository shortenedUrlRepository,
        ShortenedUrlContext shortenedUrlContext,
        UserRepository userRepository)
    {
        _context = context;
        _logger = logger.CreateLogger("Logs");
        ShortenedUrlRepository = shortenedUrlRepository;
        ShortenedUrlContext = shortenedUrlContext;
        UserRepository = userRepository;

    }

    public IShortenedUrlRepository ShortenedUrlRepository { get; private set; }

    public IShortenedUrlContext ShortenedUrlContext { get; private set; }

    public IUserRepository UserRepository { get; private set; }

    public async Task CompleteAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}