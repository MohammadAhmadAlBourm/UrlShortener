using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetShortenedUrls;

public sealed record GetShortenedUrlsQuery() : IRequest<IEnumerable<GetShortenedUrlsResponse>>;