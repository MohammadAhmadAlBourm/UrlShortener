using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.ShortenedUrls.Commands.Create;

internal sealed class CreateShorterUrlValidator : AbstractValidator<CreateShorterUrlCommand>
{
    public CreateShorterUrlValidator()
    {
        RuleFor(x => x.LongUrl)
            .NotEmpty()
            .WithMessage("URL is Required")
            .Must(IsValidUrl)
            .WithMessage("The provided URL is not valid.");
    }

    private bool IsValidUrl(string url)
    {
        var urlPattern = @"^(http|https):\/\/([\w-]+(\.[\w-]+)+)([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$";
        return Regex.IsMatch(url, urlPattern);
    }
}