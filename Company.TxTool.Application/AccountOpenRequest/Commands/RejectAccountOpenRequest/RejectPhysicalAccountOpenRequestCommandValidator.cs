using FluentValidation;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.RejectAccountOpenRequest;

public class RejectPhysicalAccountOpenRequestCommandValidator : AbstractValidator<RejectPhysicalAccountOpenRequestCommand>
{
    public RejectPhysicalAccountOpenRequestCommandValidator()
    {
        RuleFor(x => x.Guid)
            .NotNull().NotEmpty();
        RuleFor(x => x.Payload.RejectReason)
            .NotNull().NotEmpty().MaximumLength(1000);
    }
}
