using Application.Abstractions.Messaging;

namespace Application.ShortenedUrls.Commands.Create;

public sealed record CreateShorterUrlCommand(
    string LongUrl) : ICommand<CreateShorterUrlResponse>;