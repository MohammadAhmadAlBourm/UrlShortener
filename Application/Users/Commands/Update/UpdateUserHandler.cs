using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Users.Commands.Update;

internal sealed class UpdateUserHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : ICommandHandler<UpdateUserCommand, UpdateUserResponse>
{
    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        await _unitOfWork.UserRepository.Update(user, cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}