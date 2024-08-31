using Application.Abstractions.Authentication;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.ShortenedUrls.Queries.GetMyUrls;

internal sealed class GetMyUrlsHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    : IRequestHandler<GetMyUrlsQuery, IEnumerable<GetMyUrlsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IUserContext _userContext = userContext;


    public async Task<IEnumerable<GetMyUrlsResponse>> Handle(GetMyUrlsQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId;

        var urls = await _unitOfWork.ShortenedUrlRepository.GetByUserId(userId, cancellationToken);

        return _mapper.Map<IEnumerable<GetMyUrlsResponse>>(urls);
    }
}