using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

internal sealed class GetByCodeHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : IRequestHandler<GetByCodeQuery, GetByCodeResponse>
{
    public async Task<GetByCodeResponse> Handle(GetByCodeQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.ShortenedUrlRepository.GetByCode(request.Code, cancellationToken);
        return _mapper.Map<GetByCodeResponse>(response);
    }
}