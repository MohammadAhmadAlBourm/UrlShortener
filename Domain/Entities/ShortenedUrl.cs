namespace Domain.Entities;

public class ShortenedUrl : Entity
{
    public Guid UserId { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}