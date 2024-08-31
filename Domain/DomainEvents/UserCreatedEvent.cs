using Domain.Abstractions;
using Domain.Entities;

namespace Domain.DomainEvents;

public sealed record UserCreatedEvent(User User) : IDomainEvent;