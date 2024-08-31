using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.ShortenedUrls.Queries.GetShortenedUrls;

internal sealed class GetShortenedUrlsHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : IRequestHandler<GetShortenedUrlsQuery, IEnumerable<GetShortenedUrlsResponse>>
{
    public async Task<IEnumerable<GetShortenedUrlsResponse>> Handle(GetShortenedUrlsQuery request, CancellationToken cancellationToken)
    {
        var urls = await _unitOfWork.ShortenedUrlRepository.GetShortenedUrls(cancellationToken);

        return _mapper.Map<IEnumerable<GetShortenedUrlsResponse>>(urls);
    }
}