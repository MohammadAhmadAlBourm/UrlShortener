using Domain.Entities;
using Mapster;

namespace Application.ShortenedUrls.Queries.GetMyUrls;

internal static class GetMyUrlsMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetMyUrlsResponse>.NewConfig();
    }
}