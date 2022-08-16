using Cushwake.TreasuryTool.Domain.Common.Enums;
using FluentValidation;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.SubmitAccountOpenRequest
{
    public class BaseSubmitPhysicalAccountOpenRequestCommandValidator : AbstractValidator<BaseSubmitPhysicalAccountOpenRequestCommand>
    {
        public BaseSubmitPhysicalAccountOpenRequestCommandValidator()
        {
            RuleFor(x => x.Payload.DatabaseTypeID)
                 .NotNull()
                 .WithMessage("DatabaseType is required")
                 .GreaterThanOrEqualTo(1)
                 .WithMessage("DatabaseType is invalid");

            RuleFor(x => x.Payload.ClientName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Payload.ClientRef)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.Payload.CurrencyID)
               .NotNull()
               .WithMessage("Currency is required")
               .GreaterThanOrEqualTo(1)
               .WithMessage("Currency is invalid");

            RuleFor(x => x.Payload.AccountTypeID)
                .NotNull()
                .WithMessage("Account Type is required")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Account Type is invalid");

            RuleFor(x => x.Payload.ReconciliationFrequency)
                .NotNull()
                .WithMessage("Reconciliation Frequency is required");

            RuleFor(x => x.Payload.ReconciliationFrequency)
                .Must(item => ReconciliationFrequencyEnum.TryFromName(item, out _))
                .WithMessage("The ReconciliationFrequency is invalid.");

            RuleFor(x => x.Payload.PrefferedCashbookID)
               .NotNull()
               .NotEmpty();

            //ToDo need to check with picklist values.
            //When(x => x.Payload.AccountTypeID > 0, () =>
            //{
            //    RuleFor(x => x.Payload.TenancyReferenceNumber).NotNull();
            //    RuleFor(x => x.Payload.TenantName).NotNull();
            //});

            When(x => x.Payload.Amount > 0, () =>
            {
                RuleFor(x => x.Payload.DateReceived)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Date Received is required.");
            });

            RuleFor(x => x.Payload.BankReconciliationsToBePreparedById)
                .NotNull()
                .WithMessage("Bank Reconciliations To Be Prepared By is required")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Bank Reconciliations To Be Prepared By is invalid");

            RuleFor(x => x.Payload.BankReconciliationsToBeReviewedById)
                .NotNull()
                .WithMessage("Bank Reconciliations To Be Reviewed By is required")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Bank Reconciliations To Be Reviewed By is invalid");

            RuleFor(x => x).Must(item => item.Payload.BankReconciliationsToBePreparedById != item.Payload.BankReconciliationsToBeReviewedById)
                .WithMessage("Bank Reconciliations To Be Reviewed By and Bank Reconciliations To Be Prepared By cant be same");

            RuleFor(x => x.Payload.SupportingDocumentation)
                .NotNull()
                .NotEmpty()
                .Must(NotEqualZero)
                .WithMessage("Supporting documentation is required");

            bool NotEqualZero(List<int> ints)
            {
                return ints.All(i => i != 0);
            }
        }
    }
}
