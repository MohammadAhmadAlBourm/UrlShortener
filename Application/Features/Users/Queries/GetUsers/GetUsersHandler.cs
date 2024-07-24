using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

internal sealed class GetUsersHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersResponse>>
{
    public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetUsers(cancellationToken);

        return _mapper.Map<IEnumerable<GetUsersResponse>>(users);
    }
}