using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByCodeHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IQueryHandler<GetByCodeQuery, GetByCodeResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<GetByCodeResponse>> Handle(GetByCodeQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.ShortenedUrlRepository.GetByCode(request.Code, cancellationToken);

        if (url is null)
        {
            return Result.Failure<GetByCodeResponse>(ShortenedUrlErrors.NotFound(request.Code));
        }

        return _mapper.Map<GetByCodeResponse>(url);
    }
}