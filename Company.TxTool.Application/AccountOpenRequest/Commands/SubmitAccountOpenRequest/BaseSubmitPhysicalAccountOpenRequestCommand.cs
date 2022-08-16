using System;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.SubmitAccountOpenRequest
{
    [AuthorizeForPermission(PermissionEnum.AorSubmit)]
    public record BaseSubmitPhysicalAccountOpenRequestCommand
    {
        protected BaseSubmitPhysicalAccountOpenRequestCommand(PhysicalAccountOpenRequestRequestorSectionDto payload)
        {
            Payload = payload;
        }

        public PhysicalAccountOpenRequestRequestorSectionDto Payload
        {
            get;
        }
    }
}
