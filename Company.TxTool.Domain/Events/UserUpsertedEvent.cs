using System;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Helpers;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Events
{
    public class UserUpsertedEvent : BaseEvent
    {
        public UserUpsertedEvent(User newUser)
        {
            OldUser = null;
            NewUser = newUser;
            IsCreated = newUser.Id == 0;
        }

        public bool IsCreated
        {
            get;
        }

        public User? OldUser
        {
            get; private set;
        }

        public User NewUser
        {
            get;
        }

        public void AddOldUser(User oldUser)
        {
            OldUser = ObjectHelper.Clone(oldUser);
        }
    }
}
