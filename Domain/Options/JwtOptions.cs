using System.ComponentModel.DataAnnotations;

namespace Domain.Options;

public class JwtOptions
{
    [Required]
    public string SecretKey { get; init; } = string.Empty;
}