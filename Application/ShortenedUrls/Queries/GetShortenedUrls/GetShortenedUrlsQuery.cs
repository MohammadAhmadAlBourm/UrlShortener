using MediatR;

namespace Application.ShortenedUrls.Queries.GetShortenedUrls;

public sealed record GetShortenedUrlsQuery() : IRequest<IEnumerable<GetShortenedUrlsResponse>>;