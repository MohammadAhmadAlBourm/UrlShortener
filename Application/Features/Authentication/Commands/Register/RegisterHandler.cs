using Application.Helper;
using Domain.Entities;
using Domain.Options;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Options;
using UrlShortener.Services;

namespace Application.Features.Authentication.Commands.Register;

internal sealed class RegisterHandler(
    IUserRepository _userRepository,
    IMapper _mapper,
    IOptions<PasswordHasherOptions> _options)
    : IRequestHandler<RegisterCommand, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        user.Id = Guid.NewGuid();
        user.Username = user.Email.Split('@')[0];
        user.Salt = PasswordHasher.GenerateSalt();
        user.Password = PasswordHasher.ComputeHash(user.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);
        user.Roles =
        [
            "Customer"
        ];

        await _userRepository.Create(user, cancellationToken);

        return _mapper.Map<RegisterResponse>(user);
    }
}