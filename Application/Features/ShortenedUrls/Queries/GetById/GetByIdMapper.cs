using Domain.Entities;
using Mapster;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByIdMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetByIdResponse>.NewConfig();
    }
}