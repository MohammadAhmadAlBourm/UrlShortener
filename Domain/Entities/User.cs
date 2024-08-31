using Domain.Enums;

namespace Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateOnly BirthOfDate { get; set; }
    public int Age { get; set; }
    public string MobileNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public bool IsMobileNumberVerified { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool IsActive { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime? BlockedDateTime { get; set; }
    public List<Role> Roles { get; set; } = [];
    public ICollection<ShortenedUrl> ShortenedUrls { get; set; } = [];
}