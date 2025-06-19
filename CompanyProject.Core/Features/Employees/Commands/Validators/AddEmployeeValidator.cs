using CompanyProject.Core.Features.Employees.Commands.Models;
using CompanyProject.Service.Interfaces;
using FluentValidation;

namespace CompanyProject.Core.Features.Employees.Commands.Validators
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeComand>
    {
        private readonly IEmployeeService employeeService;

        public AddEmployeeValidator(IEmployeeService employeeService)
        {
            ApplyValidtionsRules();
            ApplyCustomeValidationsRules();
            this.employeeService = employeeService;
        }

        public void ApplyValidtionsRules()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null")
                .MaximumLength(20).WithMessage("Must be less than 20 char");

            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Must be not empty")
                .NotNull().WithMessage("Must be not null")
                .MaximumLength(100).WithMessage("Must be less than 100 char");
        }

        public async void ApplyCustomeValidationsRules()
        {
            RuleFor(e => e.Name)
                .MustAsync(async (Key, CancellationToken) => !await employeeService.IsNameExistAsync(Key))
                .WithMessage("Already exist");
        }
    }
}
