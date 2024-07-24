using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetMyUrls;

public sealed record GetMyUrlsQuery() : IRequest<IEnumerable<GetMyUrlsResponse>>;