using Application.Abstractions;

namespace Application.Features.ShortenedUrls.Commands.Create;

public sealed record CreateShorterUrlCommand(
    string LongUrl) : ICommand<CreateShorterUrlResponse>;