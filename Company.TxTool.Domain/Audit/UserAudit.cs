using System;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Helpers;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Audit
{
    public class UserAudit : IBelongToTenant, IConfirmToCwDbTableStandard
    {
        private UserAudit()
        {
            Type = default!;
            Action = default!;
            ActionedByEmail = default!;
            Summary = default!;
            DetailsAsJson = default!;
        }

        public UserAudit(bool isCreated, User? oldUser, User newUser, UserLite actionedUser) : this()
        {
            UserId = newUser.Id;
            Type = nameof(User);
            Action = isCreated ? "Create" : "Update";
            ActionedByEmail = actionedUser.WorkEmail;
            ActionedById = actionedUser.UserID;
            ActionedOn = DateTime.UtcNow;
            Summary = $"User '{newUser.WorkEmail}' {(isCreated ? "created" : "updated")}.";
            DetailsAsJson = JsonHelper.GetJson(GetFieldAuditInfo(oldUser, newUser));
        }

        private static FieldAuditInfo GetFieldAuditInfo(User? oldUser, User newUser)
        {
            var fieldAudit = new FieldAuditInfo();
            fieldAudit.AddSimpleAudit("Name", oldUser?.Name, newUser.Name);
            fieldAudit.AddSimpleAudit("Email", oldUser?.WorkEmail, newUser.WorkEmail);
            fieldAudit.AddSimpleAudit("Role", oldUser?.Role?.ApplicationRoleCode.Name, newUser.Role.ApplicationRoleCode.Name);
            fieldAudit.AddSimpleAudit("IsActive", oldUser?.IsActive, newUser.IsActive);
            fieldAudit.AddSimpleAudit("Permissions", oldUser?.GetPermissionsCodesForAudit(), newUser.GetPermissionsCodesForAudit());
            return fieldAudit;
        }

        public int Id
        {
            get; private set;
        }

        public int UserId
        {
            get; private set;
        }

        public string Type
        {
            get; private set;
        }

        public string Action
        {
            get; private set;
        }

        public string ActionedByEmail
        {
            get; init;
        }

        public int ActionedById
        {
            get; init;
        }

        public DateTime ActionedOn
        {
            get; private set;
        }

        public string Summary
        {
            get; init;
        }

        public string DetailsAsJson
        {
            get; init;
        }
    }
}
