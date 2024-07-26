using Application.Abstractions.Messaging;

namespace Application.Features.ShortenedUrls.Commands.Create;

public sealed record CreateShorterUrlCommand(
    string LongUrl) : ICommand<CreateShorterUrlResponse>;