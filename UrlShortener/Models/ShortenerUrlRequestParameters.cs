using UrlShortener.Database;
using UrlShortener.Services;

namespace UrlShortener.Models;

public sealed record ShortenerUrlRequestParameters(
    ShortenerUrlRequest Request,
    IUrlShorteningService UrlShorteningService,
    ApplicationDbContext ApplicationDbContext,
    HttpContext HttpContext);