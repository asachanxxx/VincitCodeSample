using System;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Notification
{
    public class Notification : BaseAuditableEntity, IBelongToTenant
    {
        private Notification()
        {
            Owner = default!;
            Type = default!;
            Message = default!;
        }

        public Notification(int ownerId, NotificationTypeEnum type, string message, int targetEntityId) : this()
        {
            OwnerId = ownerId;
            Type = type;
            Message = message;
            TargetEntityId = targetEntityId;
            IsUnread = true;
        }

        public int OwnerId
        {
            get; private set;
        }

        public virtual User Owner
        {
            get; private set;
        }

        public NotificationTypeEnum Type
        {
            get; private set;
        }

        public string Message
        {
            get; private set;
        }

        public bool IsUnread
        {
            get; private set;
        }

        public int? TargetEntityId
        {
            get; set;
        }

        public string? TargetEntityType
        {
            get; set;
        }

        public void Read()
        {
            IsUnread = false;
        }
    }
}
