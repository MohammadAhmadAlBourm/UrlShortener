using Application.Abstractions;
using Domain.Entities;

namespace Application.Features.Users.Commands.Update;

public sealed record UpdateUserCommand(
    Guid Id,
    string Name,
    List<Role> Roles) : ICommand<UpdateUserResponse>;