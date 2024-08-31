using Domain.Entities;
using Mapster;

namespace Application.ShortenedUrls.Queries.GetById;

internal sealed class GetByIdMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetUrlByIdResponse>.NewConfig();
    }
}