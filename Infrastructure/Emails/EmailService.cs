using Domain.Abstractions;
using Domain.Models;
using FluentEmail.Core;
using FluentEmail.Razor;

namespace Infrastructure.Emails;

public class EmailService : IEmailService
{
    public async Task Send(EmailRequest request)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Views", "GreetingsEmailTemplate.cshtml");
        string template = await File.ReadAllTextAsync(path);

        Email.DefaultRenderer = new RazorRenderer();


        Email
           .From("")
           .To(request.Email)
           .Subject(request.Subject)
           .UsingTemplate(template, request);
    }
}