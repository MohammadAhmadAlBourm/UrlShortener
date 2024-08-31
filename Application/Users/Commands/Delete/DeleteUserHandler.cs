using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Repositories;

namespace Application.Users.Commands.Delete;

internal sealed class DeleteUserHandler(IUnitOfWork _unitOfWork) : ICommandHandler<DeleteUserCommand, bool>
{
    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.Delete(request.Id, cancellationToken);
    }
}