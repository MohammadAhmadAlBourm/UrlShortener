namespace Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = [];
    public ICollection<ShortenedUrl> ShortenedUrls { get; set; } = [];
}