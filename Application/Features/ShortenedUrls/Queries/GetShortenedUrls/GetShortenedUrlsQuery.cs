using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

public sealed record GetShortenedUrlsQuery() : IRequest<IEnumerable<GetShortenedUrlsResponse>>;