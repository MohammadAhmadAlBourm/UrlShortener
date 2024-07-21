namespace Domain.Repositories;

public interface IUnitOfWork
{
    IAuthenticationRepository AuthenticationRepository { get; }
    IShortenedUrlRepository ShortenedUrlRepository { get; }
    IShortenedUrlContext ShortenedUrlContext { get; }
    IUserRepository UserRepository { get; }
    IUserContext UserContext { get; }

    Task CompleteAsync(CancellationToken cancellationToken);
}