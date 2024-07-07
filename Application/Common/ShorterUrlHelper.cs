namespace Application.Common;

public static class ShorterUrlHelper
{
    private const int NumberOfCharsInShortLink = 7;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static string GenerateUniqueCode()
    {
        Random random = new();
        var codeChars = new char[NumberOfCharsInShortLink];

        for (var i = 0; i < NumberOfCharsInShortLink; i++)
        {
            var randomIndex = random.Next(Alphabet.Length - 1);
            codeChars[i] = Alphabet[randomIndex];
        }

        var code = new string(codeChars);

        return code;
    }
}