using Domain.Repositories;
using MapsterMapper;
using MediatR;
using UrlShortener.Services;

namespace Application.Features.Authentication.Queries.GetProfile;

internal sealed class GetProfileHandler(
    IUserRepository _userRepository,
    IUserContext _userContext,
    IMapper _mapper) : IRequestHandler<GetProfileQuery, GetProfileResponse>
{
    public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(_userContext.UserId, cancellationToken);

        return _mapper.Map<GetProfileResponse>(user);
    }
}