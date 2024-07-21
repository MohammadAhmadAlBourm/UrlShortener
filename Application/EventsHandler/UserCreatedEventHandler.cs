using Domain.Email;
using Domain.Events;
using Domain.Models;
using MediatR;

namespace Application.EventsHandler;

internal sealed class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly IEmailService _emailService;

    public UserCreatedEventHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        var user = notification.User;

        await _emailService.Send(new EmailRequest()
        {
            Email = user.Email,
            Subject = "Greetings",
            User = user
        });

    }
}