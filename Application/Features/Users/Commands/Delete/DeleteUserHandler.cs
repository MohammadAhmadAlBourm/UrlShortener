using Application.Abstractions;
using Domain.Abstractions;
using Domain.Repositories;

namespace Application.Features.Users.Commands.Delete;

internal sealed class DeleteUserHandler(IUnitOfWork _unitOfWork) : ICommandHandler<DeleteUserCommand, bool>
{
    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.UserRepository.Delete(request.Id, cancellationToken);
        return response.IsSuccess;
    }
}