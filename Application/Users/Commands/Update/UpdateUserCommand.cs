using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Users.Commands.Update;

public sealed record UpdateUserCommand(
    Guid Id,
    string Name,
    List<Role> Roles) : ICommand<UpdateUserResponse>;