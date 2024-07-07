using Application.Helper;
using Domain.Options;
using MediatR;
using Microsoft.Extensions.Options;
using UrlShortener.Services;

namespace Application.Features.Authentication.Commands.Login;

internal sealed class LoginHandler(
    IUserRepository _userRepository,
    IAuthenticationRepository _authenticationRepository,
    IOptions<PasswordHasherOptions> _options) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (user == null)
        {
            throw new Exception("");
        }

        string password = PasswordHasher.ComputeHash(request.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);

        if (password != user.Password)
        {
            throw new Exception("");
        }

        var token = _authenticationRepository.GenerateToken(user);


        return new LoginResponse
        {
            Token = token
        };

    }
}