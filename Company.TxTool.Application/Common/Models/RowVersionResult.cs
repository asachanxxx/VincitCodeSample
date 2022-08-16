using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.Common.Models
{
    public class RowVersionResult
    {
        public RowVersionResult(BaseAccountOpenRequest entity)
        {
            RowVersion = entity.RowVersion;
            Guid = entity.Guid;
        }

        public Guid Guid
        {
            get;
        }

        public byte[] RowVersion
        {
            get;
        }
    }
}
