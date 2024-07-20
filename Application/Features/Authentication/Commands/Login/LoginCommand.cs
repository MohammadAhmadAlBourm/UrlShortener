using Application.Abstractions;

namespace Application.Features.Authentication.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password) : ICommand<LoginResponse>;