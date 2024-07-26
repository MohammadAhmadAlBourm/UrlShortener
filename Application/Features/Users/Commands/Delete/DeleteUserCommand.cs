using Application.Abstractions.Messaging;

namespace Application.Features.Users.Commands.Delete;

public sealed record DeleteUserCommand(Guid Id) : ICommand<bool>;