using Application.Abstractions.Messaging;

namespace Application.Users.Commands.Register;

public sealed record RegisterCommand(
    string Name,
    string Email,
    string Password) : ICommand<RegisterResponse>;