using MediatR;

namespace Application.Features.ShortenedUrls.Commands.Delete;

public sealed record DeleteShorterUrlCommand(Guid Id) : IRequest<bool>;