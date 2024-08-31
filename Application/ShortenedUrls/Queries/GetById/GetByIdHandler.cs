using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.ShortenedUrls.Queries.GetById;

internal sealed class GetByIdHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : IQueryHandler<GetByIdQuery, GetUrlByIdResponse>
{
    public async Task<Result<GetUrlByIdResponse>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.ShortenedUrlRepository.GetById(request.Id, cancellationToken);

        if (url is null)
        {
            return Result.Failure<GetUrlByIdResponse>(ShortenedUrlErrors.NotFound(request.Id));
        }

        return _mapper.Map<GetUrlByIdResponse>(url);
    }
}