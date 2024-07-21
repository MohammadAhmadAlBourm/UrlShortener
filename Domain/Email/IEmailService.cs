using Domain.Models;

namespace Domain.Email;

public interface IEmailService
{
    Task Send(EmailRequest request);
}