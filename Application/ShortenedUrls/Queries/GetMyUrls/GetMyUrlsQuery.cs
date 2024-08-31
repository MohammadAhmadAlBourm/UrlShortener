using MediatR;

namespace Application.ShortenedUrls.Queries.GetMyUrls;

public sealed record GetMyUrlsQuery() : IRequest<IEnumerable<GetMyUrlsResponse>>;