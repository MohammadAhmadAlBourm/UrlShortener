using Application.Abstractions.Messaging;
using Application.Helper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Options;
using MapsterMapper;
using Microsoft.Extensions.Options;
using UrlShortener.Services;

namespace Application.Features.Authentication.Commands.Register;

internal sealed class RegisterHandler(
    IUserRepository _userRepository,
    IMapper _mapper,
    IOptions<PasswordHasherOptions> _options)
    : ICommandHandler<RegisterCommand, RegisterResponse>
{
    public async Task<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        user.Id = Ulid.NewUlid().ToGuid();
        user.Username = user.Email.Split('@')[0];
        user.Salt = PasswordHasher.GenerateSalt();
        user.Password = PasswordHasher.ComputeHash(user.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);
        user.Roles =
        [
            Role.Customer
        ];

        bool isExist = await _userRepository.IsExist(user.Username, cancellationToken);

        if (isExist)
        {
            return Result.Failure<RegisterResponse>(UserErrors.UserEmailAlreadyExist);
        }

        var response = await _userRepository.Create(user, cancellationToken);

        return response.IsSuccess
            ? _mapper.Map<RegisterResponse>(user)
            : Result.Failure<RegisterResponse>(UserErrors.NotSavedSuccessfully);
    }
}