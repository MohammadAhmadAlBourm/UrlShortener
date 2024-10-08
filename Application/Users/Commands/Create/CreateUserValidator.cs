﻿using Domain.Enums;
using FluentValidation;

namespace Application.Users.Commands.Create;

internal sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required")
            .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

        RuleFor(x => x.MiddleName)
            .NotEmpty().WithMessage("Middle Name is required")
            .MaximumLength(50).WithMessage("Middle Name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required")
            .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");

        RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 8).WithMessage("Password must be exactly 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("At least one role is required.")
                .Must(roles => roles.All(role => Enum.IsDefined(typeof(Role), role)))
                .WithMessage("Invalid role specified.");
    }
}