using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Features.ShortenedUrls.Queries.GetById;

internal sealed class GetByIdHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : IQueryHandler<GetByIdQuery, GetUrlByIdResponse>
{
    public async Task<Result<GetUrlByIdResponse>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.ShortenedUrlRepository.GetById(request.Id, cancellationToken);

        if (url is null)
        {
            return Result.Failure<GetUrlByIdResponse>(ShortenedUrlErrors.ShortenedUrlIdNotFound);
        }

        return _mapper.Map<GetUrlByIdResponse>(url);
    }
}