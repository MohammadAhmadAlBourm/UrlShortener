using Application.Abstractions;

namespace Application.Features.Users.Commands.Delete;

public sealed record DeleteUserCommand(Guid Id) : ICommand<bool>;