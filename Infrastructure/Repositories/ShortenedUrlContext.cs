using Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories;

internal sealed class ShortenedUrlContext(IHttpContextAccessor httpContextAccessor) : IShortenedUrlContext
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string Scheme => _httpContextAccessor
        .HttpContext
        .Request
        .Scheme;

    public string Host => _httpContextAccessor
        .HttpContext
        .Request
        .Host
        .ToString();
}