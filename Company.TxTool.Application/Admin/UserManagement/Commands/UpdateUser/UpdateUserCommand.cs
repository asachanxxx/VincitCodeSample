using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Events;
using Cushwake.TreasuryTool.Domain.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Commands.UpdateUser;

[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserCommand()
    {
        Name = default!;
        ApplicationRoleCode = default!;
        Permissions = default!;
        RowVersion = default!;
    }

    public Guid Guid
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public int CopiedFromApplicationRoleID
    {
        get; set;
    }

    public string ApplicationRoleCode
    {
        get; set;
    }

    public bool IsActive
    {
        get; set;
    }

    public byte[] RowVersion
    {
        get; set;
    }

    public IList<UserPermissionDto> Permissions
    {
        get; set;
    }

    public class UserPermissionDto
    {
        public int PermissionID
        {
            get; set;
        }
    }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.Users
            .Include(u => u.Role)
            .ThenInclude(r => r.ApplicationRoleBPermissions)
            .ThenInclude(rp => rp.Permission)
            .SingleAsync(u => u.UserGraphId == dto.Guid, cancellationToken);

        var updatedEvent = new UserUpsertedEvent(existingUser);
        updatedEvent.AddOldUser(existingUser);

        existingUser.Name = dto.Name;
        existingUser.IsActive = dto.IsActive;
        existingUser.RowVersion = dto.RowVersion;
        if (dto.ApplicationRoleCode != existingUser.Role.ApplicationRoleCode.Name)
        {
            existingUser.Role = new ApplicationRole(dto.ApplicationRoleCode, dto.CopiedFromApplicationRoleID);
        }
        else
        {
            existingUser.Role.ApplicationRoleBPermissions.Clear();
        }

        foreach (var item in dto.Permissions)
        {
            existingUser.Role.AddPermission(item.PermissionID);
        }

        existingUser.AddDomainEvent(updatedEvent);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
