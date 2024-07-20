using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using UrlShortener.Services;

namespace Application.Features.Authentication.Queries.GetProfile;

internal sealed class GetProfileHandler(
    IUserRepository _userRepository,
    IUserContext _userContext,
    IMapper _mapper) : IQueryHandler<GetProfileQuery, GetProfileResponse>
{
    public async Task<Result<GetProfileResponse>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(_userContext.UserId, cancellationToken);

        if (user is { })
        {
            return Result.Failure<GetProfileResponse>(UserErrors.UserIdNotFound);
        }

        return _mapper.Map<GetProfileResponse>(user);
    }
}