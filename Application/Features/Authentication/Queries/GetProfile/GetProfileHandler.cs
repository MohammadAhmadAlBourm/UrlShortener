using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Features.Authentication.Queries.GetProfile;

internal sealed class GetProfileHandler(
    IUnitOfWork _unitOfWork,
    IUserContext _userContext,
    IMapper _mapper) : IQueryHandler<GetProfileQuery, GetProfileResponse>
{
    public async Task<Result<GetProfileResponse>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetById(_userContext.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<GetProfileResponse>(UserErrors.UserIdNotFound);
        }

        return _mapper.Map<GetProfileResponse>(user);
    }
}