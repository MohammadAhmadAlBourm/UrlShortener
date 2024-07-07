using Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories;

internal sealed class ShortenedUrlContext(IHttpContextAccessor httpContextAccessor) : IShortenedUrlContext
{
    public string Scheme => httpContextAccessor
        .HttpContext
        .Request
        .Scheme;

    public string Host => httpContextAccessor
        .HttpContext
        .Request
        .Host
        .ToString();
}