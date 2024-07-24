using Application.Abstractions;
using Application.Common;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Options;
using Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.Commands.Create;

internal sealed class CreateUserHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IOptions<PasswordHasherOptions> _options) : ICommandHandler<CreateUserCommand, CreateUserResponse>
{
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        user.Id = Ulid.NewUlid().ToGuid();
        user.Username = user.Email.Split('@')[0];
        user.Salt = PasswordHasher.GenerateSalt();
        user.Password = PasswordHasher.ComputeHash(user.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);

        bool isExist = await _unitOfWork.UserRepository.IsExist(user.Username, cancellationToken);

        if (isExist)
        {
            return Result.Failure<CreateUserResponse>(UserErrors.UserEmailAlreadyExist);
        }

        await _unitOfWork.UserRepository.Create(user, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}