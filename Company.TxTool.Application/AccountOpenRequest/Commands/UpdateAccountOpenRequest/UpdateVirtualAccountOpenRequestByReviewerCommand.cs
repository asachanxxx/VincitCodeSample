using Ardalis.GuardClauses;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.UpdateAccountOpenRequest;

[AuthorizeForPermission(PermissionEnum.AorSave)]
public record UpdateVirtualAccountOpenRequestByReviewerCommand : IRequest<Unit>
{
    public UpdateVirtualAccountOpenRequestByReviewerCommand()
    {
        PayingInBooksToGoTo = default!;
        AccountNumber = default!;
        TrampsCashbookId = default!;
        BankRe1 = default!;
        AmountOfOpeninigBalanceMovedToAccount = default!;
        RejectReason = default!;
        DepositLetterTenantRef = default!;
        BankAccountName = default!;
        AccountGroup = default!;
    }
    public Guid Guid
    {
        get; set;
    }
    public string? TrampsCashbookId
    {
        get; set;
    }
    public DateTime? DateSetupOnDatabase
    {
        get; set;
    }
    public string? BankAccountName
    {
        get; set;
    }
    public string? BankRe1
    {
        get; set;
    }
    public DateTime? DateOpened
    {
        get; set;
    }
    public string? AccountGroup
    {
        get; set;
    }
    public string? PayingInBooksToGoTo
    {
        get; set;
    }
    public decimal? AmountOfOpeninigBalanceMovedToAccount
    {
        get; set;
    }
    public DateTime? DateAmountOfOpeningBalanceMovedIntoAccount
    {
        get; set;
    }
    public DateTime? DateRegisterEntryCompleted
    {
        get; set;
    }
    public DateTime? AccountGroupUpdatedOn
    {
        get; set;
    }
    public string? DepositLetterTenantRef
    {
        get; set;
    }
    public DateTime? DepositLetterLastLetterSent
    {
        get; set;
    }
    public string? Notes
    {
        get; set;
    }
    public string? RejectReason
    {
        get; set;
    }
    public string? PhysicalBankAdminSortCode
    {
        get; set;
    }
    public string? AccountNumber
    {
        get; set;
    }
    public string? PostingRulesInBMAPDebtorClientRef
    {
        get; set;
    }
    public string? TransactionTypeCode
    {
        get; set;
    }
    public string? PropertyNumber
    {
        get; set;
    }
    public string? ExpenseCode
    {
        get; set;
    }
    public string? ScheduleRef
    {
        get; set;
    }
    public string? ChartCode
    {
        get; set;
    }
    public string? VirtualAccountNumber
    {
        get; set;
    }
}

public class UpdateVirtualAccountOpenRequestByReviewerCommandHandler : IRequestHandler<UpdateVirtualAccountOpenRequestByReviewerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public UpdateVirtualAccountOpenRequestByReviewerCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(UpdateVirtualAccountOpenRequestByReviewerCommand dto, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(dto.Guid);

        var request = await _context.VirtualAccountOpenRequests
               .Where(a => a.Guid == dto.Guid)
               .SingleOrDefaultAsync(cancellationToken);
        Guard.Against.Null(request);

        request.TrampsCashbookId = dto.TrampsCashbookId;
        request.DateSetupOnDatabase = dto.DateSetupOnDatabase;
        request.BankAccountName = dto.BankAccountName;
        request.BankRe1 = dto.BankRe1;
        request.DateOpened = dto.DateOpened;
        request.AccountGroup = dto.AccountGroup;
        request.AmountOfOpeninigBalanceMovedToAccount = dto.AmountOfOpeninigBalanceMovedToAccount;
        request.DateAmountOfOpeningBalanceMovedIntoAccount = dto.DateAmountOfOpeningBalanceMovedIntoAccount;
        request.DateRegisterEntryCompleted = dto.DateRegisterEntryCompleted;
        request.AccountGroupUpdatedOn = dto.AccountGroupUpdatedOn;
        request.DepositLetterTenantRef = dto.DepositLetterTenantRef;
        request.DepositLetterLastLetterSent = dto.DepositLetterLastLetterSent;
        request.Notes = dto.Notes;
        request.PhysicalBankAdminSortCode = dto.PhysicalBankAdminSortCode;
        request.VirtualAccountNumber = dto.VirtualAccountNumber;
        request.PostingRulesInBMAPDebtorClientRef = dto.PostingRulesInBMAPDebtorClientRef;
        request.TransactionTypeCode = dto.TransactionTypeCode;
        request.PropertyNumber = dto.PropertyNumber;
        request.ExpenseCode = dto.ExpenseCode;
        request.ScheduleRef = dto.ScheduleRef;
        request.ChartCode = dto.ChartCode;
        request.VirtualAccountNumber = dto.VirtualAccountNumber;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
