using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Users.Commands.Create;

public sealed record CreateUserCommand(
    string Name,
    string Email,
    string Password,
    List<Role> Roles) : ICommand<CreateUserResponse>;