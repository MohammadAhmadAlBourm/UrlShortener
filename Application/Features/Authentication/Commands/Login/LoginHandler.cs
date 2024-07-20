using Application.Abstractions.Messaging;
using Application.Helper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Options;
using Microsoft.Extensions.Options;
using UrlShortener.Services;

namespace Application.Features.Authentication.Commands.Login;

internal sealed class LoginHandler(
    IUserRepository _userRepository,
    IAuthenticationRepository _authenticationRepository,
    IOptions<PasswordHasherOptions> _options)
    : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoginResponse>(UserErrors.UserEmailNotFound);
        }

        string password = PasswordHasher.ComputeHash(request.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);

        if (password != user.Password)
        {
            return Result.Failure<LoginResponse>(UserErrors.UserPasswordNotMatching);
        }

        var token = _authenticationRepository.GenerateToken(user);


        return new LoginResponse
        {
            Token = token
        };
    }
}