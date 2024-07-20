using Application.Abstractions;

namespace Application.Features.Authentication.Commands.Register;

public sealed record RegisterCommand(
    string Name,
    string Email,
    string Password) : ICommand<RegisterResponse>;