using System.Reflection;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Audit;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Notification;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using Cushwake.TreasuryTool.Domain.Security;
using Cushwake.TreasuryTool.Infrastructure.Common;
using Cushwake.TreasuryTool.Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private const string TenantIdColumn = "TenantID";
    private const string CreatedByIdColumn = "CreatedByID";
    private const string CreatedOnColumn = "Created";
    private const string ModifiedByIdColumn = "ModifiedByID";
    private const string ModifiedOnColumn = "Modified";
    private const string RowModifiedByColumn = "RowModifiedBy";
    private const string RowModifiedOnColumn = "RowModified";

    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly TaggedQueryCommandInterceptor _taggedQueryCommandInterceptor;
    private readonly int _tenantId;
    private readonly bool _isInDevelopment;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _mediator = default!;
        _auditableEntitySaveChangesInterceptor = default!;
        _taggedQueryCommandInterceptor = default!;
    }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor, TaggedQueryCommandInterceptor taggedQueryCommandInterceptor,
        ICurrentUserService currentUserService, IEnvironmentSettings settings)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        _taggedQueryCommandInterceptor = taggedQueryCommandInterceptor;
        _tenantId = currentUserService.User.TenantId;
        _isInDevelopment = settings.InDevelopmentEnvironment;
    }

    public virtual DbSet<AppConfig> AppConfig => Set<AppConfig>();
    public virtual DbSet<ErrorMessage> ErrorMessage => Set<ErrorMessage>();
    public virtual DbSet<Notification> Notifications => Set<Notification>();

    public virtual DbSet<PicklistType> PicklistTypes => Set<PicklistType>();
    public virtual DbSet<BasePicklistItem> PicklistItems => Set<BasePicklistItem>();

    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<ApplicationRole> ApplicationRoles => Set<ApplicationRole>();
    public virtual DbSet<Permission> Permission => Set<Permission>();
    public virtual DbSet<ApplicationRoleBPermission> ApplicationRoleBPermissions => Set<ApplicationRoleBPermission>();
    public DbSet<UserAudit> UserAudits => Set<UserAudit>();

    public DbSet<BaseAccountOpenRequest> AccountOpenRequests => Set<BaseAccountOpenRequest>();
    public DbSet<PhysicalAccountOpenRequest> PhysicalAccountOpenRequests => Set<PhysicalAccountOpenRequest>();
    public DbSet<VirtualAccountOpenRequest> VirtualAccountOpenRequests => Set<VirtualAccountOpenRequest>();
    public DbSet<AccountOpenRequestType> AccountOpenRequestTypes => Set<AccountOpenRequestType>();
    public DbSet<AccountRegister> AccountRegisters => Set<AccountRegister>();

    public DbSet<SupportDocument> SupportDocuments => Set<SupportDocument>();

    public DbSet<ReconciliationSchedule> ReconciliationSchedules => Set<ReconciliationSchedule>();


    public DbSet<PhysicalAccountRegister> PhysicalAccountRegisters => Set<PhysicalAccountRegister>();

    public DbSet<VirtualAccountRegister> VirtualAccountRegisters => Set<VirtualAccountRegister>();

    public Task LoadProperty<T>(T entry, string property, CancellationToken cancellationToken) where T : class
    {
        return Entry(entry).Reference(property).LoadAsync(cancellationToken);
    }

    public Task LoadCollection<T>(T entry, string property, CancellationToken cancellationToken) where T : class
    {
        return Entry(entry).Collection(property).LoadAsync(cancellationToken);
    }

    private static readonly MethodInfo SetBelongToTenantQueryFilterMethod = typeof(ApplicationDbContext).GetMethod(nameof(SetBelongToTenantQueryFilter), BindingFlags.Instance | BindingFlags.NonPublic)!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SetupTenantIdColumnAndFilter(builder);
        SetupApplicationAuditColumns(builder);
        SetupRowVersionColumn(builder);
        SetupCwStandardAuditColumns(builder);
        DisableCascadeDelete(builder);
    }

    private static void SetupApplicationAuditColumns(ModelBuilder builder)
    {
        var auditableEntities = builder.Model.GetEntityTypes().Where(e => e.BaseType is null && e.ClrType.IsAssignableTo(typeof(BaseAuditableEntity)));
        foreach (var entity in auditableEntities)
        {
            builder.Entity(entity.ClrType).Property<DateTime?>(CreatedOnColumn).HasPrecision(2);
            builder.Entity(entity.ClrType).Property<int?>(CreatedByIdColumn);
            builder.Entity(entity.ClrType).HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(CreatedByIdColumn)
                .HasConstraintName($"FK_{entity.ClrType.Name}_{CreatedByIdColumn}");

            builder.Entity(entity.ClrType).Property<DateTime?>(ModifiedOnColumn).HasPrecision(2);
            builder.Entity(entity.ClrType).Property<int?>(ModifiedByIdColumn);
            builder.Entity(entity.ClrType).HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(ModifiedByIdColumn)
                .HasConstraintName($"FK_{entity.ClrType.Name}_{ModifiedByIdColumn}");
        }
    }

    private static void SetupCwStandardAuditColumns(ModelBuilder builder)
    {
        var entitiesConfirmingToCwDbTableStandard = builder.Model.GetEntityTypes().Where(e => e.BaseType is null && e.ClrType.IsAssignableTo(typeof(IConfirmToCwDbTableStandard)));
        foreach (var entity in entitiesConfirmingToCwDbTableStandard)
        {
            builder.Entity(entity.ClrType).Property<DateTime>(RowModifiedOnColumn).HasPrecision(2).HasDefaultValueSql("(getdate())");
            builder.Entity(entity.ClrType).Property<string>(RowModifiedByColumn).HasMaxLength(255).HasDefaultValueSql("(user_name())");
        }
    }

    private static void DisableCascadeDelete(ModelBuilder builder)
    {
        var foreignKeys = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
        foreach (var foreignKey in foreignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private void SetupTenantIdColumnAndFilter(ModelBuilder builder)
    {
        var entitiesBelongToTenant = builder.Model.GetEntityTypes().Where(e => e.BaseType is null && e.ClrType.IsAssignableTo(typeof(IBelongToTenant)));
        foreach (var entity in entitiesBelongToTenant)
        {
            if (entity.FindProperty(TenantIdColumn) == null)
            {
                builder.Entity(entity.ClrType).Property<int>(TenantIdColumn);
                builder.Entity(entity.ClrType).HasOne(typeof(Tenant))
                    .WithMany()
                    .HasForeignKey(TenantIdColumn)
                    .HasConstraintName($"FK_{entity.ClrType.Name}_{TenantIdColumn}");
            }

            SetBelongToTenantQueryFilterMethod.MakeGenericMethod(entity.ClrType).Invoke(this, new object[] { builder });
        }
    }

    private static void SetupRowVersionColumn(ModelBuilder builder)
    {
        var rowVersionableEntities = builder.Model.GetEntityTypes().Where(e => e.BaseType is null && e.ClrType.IsAssignableTo(typeof(BaseRowVersionedEntity)));
        foreach (var entity in rowVersionableEntities)
        {
            builder.Entity(entity.ClrType).Property<byte[]>(nameof(BaseRowVersionedEntity.RowVersion)).IsRowVersion();
        }
    }

    private void SetBelongToTenantQueryFilter<T>(ModelBuilder builder) where T : class, IBelongToTenant
    {
        builder.Entity<T>().HasQueryFilter(e => EF.Property<int>(e, TenantIdColumn) == _tenantId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);

        if (_isInDevelopment)
        {
            //TODO: Check if this is actually needed or the logging via console is already done from services
            optionsBuilder.AddInterceptors(_taggedQueryCommandInterceptor);

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //TODO: Move this to its own interceptor
        foreach (var entry in ChangeTracker.Entries<IBelongToTenant>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Modified:
                    entry.Property<int>(TenantIdColumn).CurrentValue = _tenantId;
                    break;
            }
        }

        //TODO: Move this to its own interceptor
        foreach (var entry in ChangeTracker.Entries<BaseRowVersionedEntity>())
        {
            var prop = entry.Property(nameof(BaseRowVersionedEntity.RowVersion));
            prop.OriginalValue = prop.CurrentValue;
        }

        int result = await base.SaveChangesAsync(cancellationToken);

        await _mediator.DispatchDomainEvents(this);

        return result;
    }
}