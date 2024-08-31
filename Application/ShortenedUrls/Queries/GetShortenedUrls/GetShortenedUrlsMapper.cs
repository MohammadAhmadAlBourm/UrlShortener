using Domain.Entities;
using Mapster;

namespace Application.ShortenedUrls.Queries.GetShortenedUrls;

internal sealed class GetShortenedUrlsMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetShortenedUrlsResponse>.NewConfig();
    }
}