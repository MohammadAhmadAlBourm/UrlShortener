using MediatR;

namespace Application.Features.ShortenedUrls.Commands.Update;

public sealed record UpdateShorterUrlCommand() : IRequest<UpdateShorterUrlResponse>;