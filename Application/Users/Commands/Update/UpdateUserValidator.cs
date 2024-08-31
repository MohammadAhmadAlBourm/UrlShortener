using Domain.Enums;
using FluentValidation;

namespace Application.Users.Commands.Update;

internal sealed class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required")
                    .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("At least one role is required.")
                .Must(roles => roles.All(role => Enum.IsDefined(typeof(Role), role)))
                .WithMessage("Invalid role specified.");
    }
}