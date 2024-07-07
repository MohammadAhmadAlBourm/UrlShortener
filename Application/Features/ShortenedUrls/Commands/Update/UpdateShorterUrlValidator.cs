using FluentValidation;

namespace Application.Features.ShortenedUrls.Commands.Update;

internal sealed class UpdateShorterUrlValidator : AbstractValidator<UpdateShorterUrlCommand>
{
    public UpdateShorterUrlValidator()
    {

    }
}