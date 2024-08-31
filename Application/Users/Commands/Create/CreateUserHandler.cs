using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Users.Commands.Create;

internal sealed class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        user.Id = Ulid.NewUlid().ToGuid();
        user.Username = user.Email.Split('@')[0];
        user.Password = _passwordHasher.Hash(user.Password);

        bool isExist = await _unitOfWork.UserRepository.IsExist(user.Username, cancellationToken);

        if (isExist)
        {
            return Result.Failure<CreateUserResponse>(UserErrors.UserEmailAlreadyExist(request.Email));
        }

        await _unitOfWork.UserRepository.Create(user, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}