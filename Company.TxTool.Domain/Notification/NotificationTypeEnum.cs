using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Notification
{
    public class NotificationTypeEnum : SmartEnum<NotificationTypeEnum>
    {
        protected NotificationTypeEnum(string name, byte value) : base(name, value)
        {
        }

        public static readonly NotificationTypeEnum System = new(nameof(System), 0);
        public static readonly NotificationTypeEnum AccountOpenRequestSubmission = new(nameof(AccountOpenRequestSubmission), 1);
        public static readonly NotificationTypeEnum AccountOpenRequestRejection = new(nameof(AccountOpenRequestRejection), 2);
        public static readonly NotificationTypeEnum AccountOpenRequestCompletion = new(nameof(AccountOpenRequestCompletion), 3);
    }
}
