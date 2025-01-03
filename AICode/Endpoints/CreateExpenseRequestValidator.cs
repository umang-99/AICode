using System;
using System.ComponentModel.DataAnnotations;
using AICode.Contracts;
using FluentValidation;

namespace AICode.Domain.Expense
{
    public class CreateExpenseRequestValidator : AbstractValidator<CreateExpenseRequest>
    {
        public CreateExpenseRequestValidator()
        {
            // Set cascade modes
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            // Validation rules
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(p => p.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(p => p.CategoryId)
                .Must(BeAValidCategory).WithMessage("Invalid expense category ID.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }

        private bool BeAValidCategory(int categoryId)
        {
            return Enum.IsDefined(typeof(ExpenseCategory), categoryId);
        }
    }
}