using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Features.Users.Queries.GetById;

internal sealed class GetUserByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetById(request.Id, cancellationToken);

        if (user is null)
        {
            return Result.Failure<GetUserByIdResponse>(UserErrors.UserIdNotFound);
        }

        return _mapper.Map<GetUserByIdResponse>(user);
    }
}