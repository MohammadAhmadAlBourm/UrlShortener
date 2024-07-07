using MapsterMapper;
using MediatR;
using UrlShortener.Services;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetShortenedUrlsHandler(
    IShortenedUrlRepository _shortenedUrlRepository,
    IMapper _mapper) : IRequestHandler<GetShortenedUrlsQuery, IEnumerable<GetShortenedUrlsResponse>>
{
    public async Task<IEnumerable<GetShortenedUrlsResponse>> Handle(GetShortenedUrlsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}