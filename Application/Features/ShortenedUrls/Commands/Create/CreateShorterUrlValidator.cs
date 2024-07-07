using FluentValidation;

namespace Application.Features.ShortenedUrls.Commands.Create;

internal sealed class CreateShorterUrlValidator : AbstractValidator<CreateShorterUrlCommand>
{
    public CreateShorterUrlValidator()
    {
        RuleFor(x => x.LongUrl).NotEmpty();
    }
}