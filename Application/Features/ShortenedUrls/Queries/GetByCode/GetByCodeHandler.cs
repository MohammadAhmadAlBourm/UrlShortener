using MapsterMapper;
using MediatR;
using UrlShortener.Services;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByCodeHandler(
    IShortenedUrlRepository _shortenedUrlRepository,
    IMapper _mapper) : IRequestHandler<GetByCodeQuery, GetByCodeResponse>
{
    public async Task<GetByCodeResponse> Handle(GetByCodeQuery request, CancellationToken cancellationToken)
    {
        var response = await _shortenedUrlRepository.GetByCode(request.Code, cancellationToken);
        return _mapper.Map<GetByCodeResponse>(response);
    }
}