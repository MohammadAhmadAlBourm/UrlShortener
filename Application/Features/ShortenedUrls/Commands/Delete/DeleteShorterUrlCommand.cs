using Application.Abstractions;

namespace Application.Features.ShortenedUrls.Commands.Delete;

public sealed record DeleteShorterUrlCommand(Guid Id) : ICommand<bool>;