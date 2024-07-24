using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByCodeHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : IQueryHandler<GetByCodeQuery, GetByCodeResponse>
{
    public async Task<Result<GetByCodeResponse>> Handle(GetByCodeQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.ShortenedUrlRepository.GetByCode(request.Code, cancellationToken);

        if (url is null)
        {
            return Result.Failure<GetByCodeResponse>(ShortenedUrlErrors.ShortenedUrlCodeNotFound);
        }

        return _mapper.Map<GetByCodeResponse>(url);
    }
}