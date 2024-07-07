﻿using Domain.Entities;
using Mapster;

namespace Application.Features.ShortenedUrls.Commands.Create;

internal static class CreateShorterUrlMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateShorterUrlCommand, ShortenedUrl>.NewConfig();
        TypeAdapterConfig<ShortenedUrl, CreateShorterUrlResponse>.NewConfig();
    }
}