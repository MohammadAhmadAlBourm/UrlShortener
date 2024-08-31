using System.ComponentModel.DataAnnotations;

namespace Domain.Options;

public class JwtOptions
{
    [Required]
    public string Secret { get; init; } = string.Empty;

    [Required]
    public string Issuer { get; init; } = string.Empty;

    [Required]
    public string Audience { get; init; } = string.Empty;

    [Required]
    public int ExpirationInMinutes { get; init; }
}