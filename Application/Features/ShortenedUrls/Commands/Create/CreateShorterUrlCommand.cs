using MediatR;

namespace Application.Features.ShortenedUrls.Commands.Create;

public sealed record CreateShorterUrlCommand(string LongUrl) : IRequest<CreateShorterUrlResponse>;