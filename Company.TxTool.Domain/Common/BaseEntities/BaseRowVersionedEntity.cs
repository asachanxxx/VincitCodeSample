using System;

namespace Cushwake.TreasuryTool.Domain.Common.BaseEntities
{
    public abstract class BaseRowVersionedEntity : BaseAuditableEntity
    {
        protected BaseRowVersionedEntity()
        {
            RowVersion = default!;
        }

        public byte[] RowVersion
        {
            get; set;
        }
    }
}
