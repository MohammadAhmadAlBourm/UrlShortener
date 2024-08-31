using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Enums;

namespace Application.Users.Commands.Create;

public sealed record CreateUserCommand(
    string FirstName,
    string MiddleName,
    string LastName,
    Gender Gender,
    DateOnly BirthOfDate,
    string MobileNumber,
    string Email,
    string Password,
    List<Role> Roles) : ICommand<CreateUserResponse>;