using Domain.Entities;
using Mapster;

namespace Application.Features.ShortenedUrls.Queries.GetMyUrls;

internal static class GetMyUrlsMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetMyUrlsResponse>.NewConfig();
    }
}