using FluentValidation;

namespace Application.ShortenedUrls.Commands.Update;

internal sealed class UpdateShorterUrlValidator : AbstractValidator<UpdateShorterUrlCommand>
{
    public UpdateShorterUrlValidator()
    {

    }
}