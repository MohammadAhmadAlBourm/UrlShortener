using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;
using UrlShortener.Services;

namespace Infrastructure.Repositories;

internal sealed class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly ILogger _logger;
    private readonly ApplicationDbContext _context;

    public UnitOfWork(
        ILoggerFactory logger,
        ApplicationDbContext context,
        AuthenticationRepository authenticationRepository,
        ShortenedUrlRepository shortenedUrlRepository,
        ShortenedUrlContext shortenedUrlContext,
        UserRepository userRepository,
        UserContext userContext
        )
    {
        _context = context;
        _logger = logger.CreateLogger("Logs");
        AuthenticationRepository = authenticationRepository;
        ShortenedUrlRepository = shortenedUrlRepository;
        ShortenedUrlContext = shortenedUrlContext;
        UserRepository = userRepository;
        UserContext = userContext;

    }
    public IAuthenticationRepository AuthenticationRepository { get; private set; }

    public IShortenedUrlRepository ShortenedUrlRepository { get; private set; }

    public IShortenedUrlContext ShortenedUrlContext { get; private set; }

    public IUserRepository UserRepository { get; private set; }

    public IUserContext UserContext { get; private set; }

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