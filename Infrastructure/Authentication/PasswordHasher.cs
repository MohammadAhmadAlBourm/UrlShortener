using Application.Abstractions.Authentication;
using Domain.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasherOptions _options;

    public PasswordHasher(IOptions<PasswordHasherOptions> options)
    {
        _options = options.Value;
    }

    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(_options.SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iteration, Algorithm, _options.HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool Verify(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split('-');
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iteration, Algorithm, _options.HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}