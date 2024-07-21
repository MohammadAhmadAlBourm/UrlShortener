using Domain.Repositories;
using MapsterMapper;
using MediatR;

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