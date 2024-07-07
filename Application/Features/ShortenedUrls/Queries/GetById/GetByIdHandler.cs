using MapsterMapper;
using MediatR;
using UrlShortener.Services;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByIdHandler(
    IShortenedUrlRepository _shortenedUrlRepository,
    IMapper _mapper) : IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}