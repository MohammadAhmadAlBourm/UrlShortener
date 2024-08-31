using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Options;
using Domain.Repositories;
using Microsoft.Extensions.Options;

namespace Application.Users.Commands.Login;

internal sealed class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly PasswordHasherOptions _options;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public LoginHandler(IUnitOfWork unitOfWork, IOptions<PasswordHasherOptions> options, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
    {
        _unitOfWork = unitOfWork;
        _options = options.Value;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByEmail(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoginResponse>(UserErrors.NotFound());
        }

        bool isVerified = _passwordHasher.Verify(request.Password, user.Password);

        if (!isVerified)
        {
            return Result.Failure<LoginResponse>(UserErrors.UserPasswordNotMatching());
        }

        var token = _tokenProvider.Create(user);

        return new LoginResponse
        {
            Token = token
        };
    }
}