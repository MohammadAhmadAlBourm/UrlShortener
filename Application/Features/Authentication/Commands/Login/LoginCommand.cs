using Application.Abstractions.Messaging;

namespace Application.Features.Authentication.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password) : ICommand<LoginResponse>;