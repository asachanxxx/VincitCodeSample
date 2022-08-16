using Cushwake.TreasuryTool.Domain.Common.Enums;
using FluentValidation;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.CreateAccountType;

public class CreateAccountTypeCommandValidator : AbstractValidator<CreateAccountTypeCommand>
{
    public CreateAccountTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().MaximumLength(255);
        RuleFor(x => x.ReconciliationFrequency)
            .NotNull().NotEmpty().MaximumLength(50);
        RuleFor(x => x.ReconciliationFrequency).Must(item => ReconciliationFrequencyEnum.TryFromName(item, true, out _))
            .WithMessage("The ReconciliationFrequency is invalid.");
    }
}
