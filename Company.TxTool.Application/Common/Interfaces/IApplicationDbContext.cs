using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Audit;
using Cushwake.TreasuryTool.Domain.Notification;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ApplicationRole> ApplicationRoles
    {
        get;
    }

    DbSet<User> Users
    {
        get;
    }

    DbSet<UserAudit> UserAudits
    {
        get;
    }

    DbSet<Notification> Notifications
    {
        get;
    }

    DbSet<AccountRegister> AccountRegisters
    {
        get;
    }

    DbSet<PhysicalAccountRegister> PhysicalAccountRegisters
    {
        get;
    }

    DbSet<VirtualAccountRegister> VirtualAccountRegisters
    {
        get;
    }

    DbSet<BaseAccountOpenRequest> AccountOpenRequests
    {
        get;
    }

    DbSet<PhysicalAccountOpenRequest> PhysicalAccountOpenRequests
    {
        get;
    }

    DbSet<VirtualAccountOpenRequest> VirtualAccountOpenRequests
    {
        get;
    }

    DbSet<ApplicationRoleBPermission> ApplicationRoleBPermissions
    {
        get;
    }

    DbSet<PicklistType> PicklistTypes
    {
        get;
    }

    DbSet<AccountOpenRequestType> AccountOpenRequestTypes
    {
        get;
    }

    DbSet<BasePicklistItem> PicklistItems
    {
        get;
    }

    DbSet<Domain.Common.SupportDocument> SupportDocuments
    {
        get;
    }

    DbSet<Domain.Reconciliation.ReconciliationSchedule> ReconciliationSchedules
    {
        get;
    }

    Task LoadProperty<T>(T entry, string property, CancellationToken cancellationToken) where T : class;

    Task LoadCollection<T>(T entry, string property, CancellationToken cancellationToken) where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}