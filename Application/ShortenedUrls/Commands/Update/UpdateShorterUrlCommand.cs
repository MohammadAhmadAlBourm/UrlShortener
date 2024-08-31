using MediatR;

namespace Application.ShortenedUrls.Commands.Update;

public sealed record UpdateShorterUrlCommand() : IRequest<UpdateShorterUrlResponse>;