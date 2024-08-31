namespace Domain.Repositories;

public interface IUnitOfWork
{
    IShortenedUrlRepository ShortenedUrlRepository { get; }
    IShortenedUrlContext ShortenedUrlContext { get; }
    IUserRepository UserRepository { get; }

    Task CompleteAsync(CancellationToken cancellationToken);
}