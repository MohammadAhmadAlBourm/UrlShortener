using Application.Abstractions.Messaging;

namespace Application.ShortenedUrls.Commands.Delete;

public sealed record DeleteShorterUrlCommand(Guid Id) : ICommand<bool>;