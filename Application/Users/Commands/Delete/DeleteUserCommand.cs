using Application.Abstractions.Messaging;

namespace Application.Users.Commands.Delete;

public sealed record DeleteUserCommand(Guid Id) : ICommand<bool>;