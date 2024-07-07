using System.ComponentModel.DataAnnotations;

namespace Domain.Options;

public class PasswordHasherOptions
{
    [Required]
    public string Pepper { get; set; } = string.Empty;

    [Required]
    public int Iteration { get; set; }
}