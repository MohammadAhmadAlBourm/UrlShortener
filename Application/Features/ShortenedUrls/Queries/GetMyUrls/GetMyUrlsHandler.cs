using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetMyUrls;

internal sealed class GetMyUrlsHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
    : IRequestHandler<GetMyUrlsQuery, IEnumerable<GetMyUrlsResponse>>
{
    public async Task<IEnumerable<GetMyUrlsResponse>> Handle(GetMyUrlsQuery request, CancellationToken cancellationToken)
    {
        var userId = _unitOfWork.UserContext.UserId;

        var urls = await _unitOfWork.ShortenedUrlRepository.GetByUserId(userId, cancellationToken);

        return _mapper.Map<IEnumerable<GetMyUrlsResponse>>(urls);
    }
}