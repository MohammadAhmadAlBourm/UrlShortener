using System.ComponentModel.DataAnnotations;

namespace Domain.Options;

public class PasswordHasherOptions
{
    [Required]
    public int SaltSize { get; set; }

    [Required]
    public int HashSize { get; set; }

    [Required]
    public int Iteration { get; set; }
}