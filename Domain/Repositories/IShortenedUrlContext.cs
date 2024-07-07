namespace Domain.Repositories;

public interface IShortenedUrlContext
{
    string Scheme { get; }
    string Host { get; }
}