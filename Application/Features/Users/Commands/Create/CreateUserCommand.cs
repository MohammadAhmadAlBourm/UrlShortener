using Application.Abstractions;
using Domain.Entities;

namespace Application.Features.Users.Commands.Create;

public sealed record CreateUserCommand(
    string Name,
    string Email,
    string Password,
    List<Role> Roles) : ICommand<CreateUserResponse>;