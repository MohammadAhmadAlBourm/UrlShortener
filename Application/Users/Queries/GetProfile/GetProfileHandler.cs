using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Users.Queries.GetProfile;

internal sealed class GetProfileHandler : IQueryHandler<GetProfileQuery, GetProfileResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetProfileHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Result<GetProfileResponse>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetById(_userContext.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<GetProfileResponse>(UserErrors.NotFound());
        }

        return _mapper.Map<GetProfileResponse>(user);
    }
}