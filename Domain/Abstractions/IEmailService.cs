using Domain.Models;

namespace Domain.Abstractions;

public interface IEmailService
{
    Task Send(EmailRequest request);
}