using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public sealed record RegisterCommand(
    string Name,
    string Email,
    string Password) : IRequest<RegisterResponse>;