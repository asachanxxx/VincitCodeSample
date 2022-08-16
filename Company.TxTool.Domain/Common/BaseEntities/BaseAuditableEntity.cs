namespace Cushwake.TreasuryTool.Domain.Common.BaseEntities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime? Created
    {
        get; set;
    }

    public int? CreatedByID
    {
        get; set;
    }

    public DateTime? Modified
    {
        get; set;
    }

    public int? ModifiedByID
    {
        get; set;
    }
}
