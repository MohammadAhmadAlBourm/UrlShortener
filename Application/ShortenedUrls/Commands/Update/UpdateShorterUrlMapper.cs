using Domain.Entities;
using Mapster;

namespace Application.ShortenedUrls.Commands.Update;

internal static class UpdateShorterUrlMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<UpdateShorterUrlCommand, ShortenedUrl>.NewConfig();
        TypeAdapterConfig<ShortenedUrl, UpdateShorterUrlResponse>.NewConfig();
    }
}