using CompanyProject.Core.Features.ApplicationUser.Commands.Models;
using FluentValidation;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class ChangeApplicationUserPasswordValidator : AbstractValidator<ChangeApplicationUserPasswordCommand>
    {
        public void ApplyValidtionsRules()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null");

            RuleFor(e => e.OldPassword)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null");

            RuleFor(e => e.NewPassword)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null");

            RuleFor(e => e.ConfirmNewPassword)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null");
        }

        public async void ApplyCustomeValidationsRules()
        {

        }
    }
}

