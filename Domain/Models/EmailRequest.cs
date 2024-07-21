using Domain.Entities;

namespace Domain.Models;

public class EmailRequest
{
    public string Email { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public User User { get; set; } = new();
}