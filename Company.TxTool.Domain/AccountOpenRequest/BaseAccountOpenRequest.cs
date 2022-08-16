using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest;

public abstract class BaseAccountOpenRequest : BaseRowVersionedEntity, IBelongToTenant
{
    protected BaseAccountOpenRequest()
    {
        ClientName = default!;
        DatabaseType = default!;
        Status = default!;
        RequestedUser = default!;
        Type = default!;
    }

    public Guid Guid
    {
        get; set;
    }

    public DateTime? RequestedOn
    {
        get; set;
    }

    public int RequestedBy
    {
        get; set;
    }

    public virtual User RequestedUser
    {
        get; private set;
    }

    public string? ClientName
    {
        get; set;
    }

    public int? DatabaseTypeID
    {
        get; set;
    }

    public virtual DatabaseType? DatabaseType
    {
        get; set;
    }

    // Although the property says ReviewedOn, it basically captures the review started date
    public DateTime? ReviewedOn
    {
        get; set;
    }

    public int? ReviewedBy
    {
        get; set;
    }

    public virtual User? ReviewedUser
    {
        get; private set;
    }

    public AccountOpenRequestTypeEnum Type
    {
        get; set;
    }

    public AccountOpenRequestStatusEnum Status
    {
        get; set;
    }

    public void Submit(IWorkflowFactory workflowFactory)
    {
        workflowFactory.GetAccountOpenRequestWorkflow(this).Fire(AccountOpenRequestTrigger.Submitting);
    }

    public void StartReview(IWorkflowFactory workflowFactory)
    {
        workflowFactory.GetAccountOpenRequestWorkflow(this).Fire(AccountOpenRequestTrigger.StartReviewing);
    }

    public void Approve(IWorkflowFactory workflowFactory)
    {
        workflowFactory.GetAccountOpenRequestWorkflow(this).Fire(AccountOpenRequestTrigger.Completing);
    }

    public void Reject(IWorkflowFactory workflowFactory)
    {
        workflowFactory.GetAccountOpenRequestWorkflow(this).Fire(AccountOpenRequestTrigger.Rejecting);
    }

    public void SetupReviewer(int reviewerId)
    {
        ReviewedBy = reviewerId;
    }

    public void SetupReviewerAndDate(int reviewerId, DateTime reviewStartedOn)
    {
        ReviewedBy = reviewerId;
        ReviewedOn = reviewStartedOn;
    }
}