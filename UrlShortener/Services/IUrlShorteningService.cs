namespace UrlShortener.Services;

public interface IUrlShorteningService
{
    Task<string> GenerateUniqueCode();
}