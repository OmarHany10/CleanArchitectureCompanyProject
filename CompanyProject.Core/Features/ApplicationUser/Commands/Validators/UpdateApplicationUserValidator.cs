using CompanyProject.Core.Features.ApplicationUser.Commands.Models;
using FluentValidation;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class UpdateApplicationUserValidator : AbstractValidator<UpdateApplicationUserCommand>
    {
        public void ApplyValidtionsRules()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null")
                .MaximumLength(50).WithMessage("Must be less than 50 char");

            RuleFor(e => e.UserName)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null")
                .MaximumLength(50).WithMessage("Must be less than 50 char");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null");


        }

        public async void ApplyCustomeValidationsRules()
        {

        }
    }
}
