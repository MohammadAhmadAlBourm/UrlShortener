using Domain.Entities;
using Mapster;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByCodeMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<ShortenedUrl, GetByCodeResponse>.NewConfig();
    }
}