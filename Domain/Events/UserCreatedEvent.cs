using Domain.Entities;
using MediatR;

namespace Domain.Events;

public sealed record UserCreatedEvent(User User) : INotification;