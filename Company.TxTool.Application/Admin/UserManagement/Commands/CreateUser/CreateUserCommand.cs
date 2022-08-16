using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Events;
using Cushwake.TreasuryTool.Domain.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Commands.CreateUser;

[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record CreateUserCommand : IRequest<int>
{
    public CreateUserCommand()
    {
        Name = default!;
        FirstName = default!;
        LastName = default!;
        WorkEmail = default!;
        ApplicationRoleCode = default!;
        UserGraphId = default!;
        Permissions = default!;
    }

    public string Name
    {
        get; set;
    }

    public string FirstName
    {
        get; set;
    }

    public string LastName
    {
        get; set;
    }

    public string WorkEmail
    {
        get; set;
    }

    public string UserGraphId
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

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand dto, CancellationToken cancellationToken)
    {
        await EnsureUserDoesNotExist(dto, cancellationToken);

        var newUser = new User(dto.Name, dto.FirstName, dto.LastName, dto.WorkEmail, Guid.Parse(dto.UserGraphId), new ApplicationRole(dto.ApplicationRoleCode, dto.CopiedFromApplicationRoleID), dto.IsActive);

        foreach (var item in dto.Permissions)
        {
            newUser.Role.AddPermission(item.PermissionID);
        }

        newUser.AddDomainEvent(new UserUpsertedEvent(newUser));

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        return newUser.Id;
    }

    private async Task EnsureUserDoesNotExist(CreateUserCommand dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.Users.AsNoTracking()
            .Where(u => u.WorkEmail == dto.WorkEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser is not null)
        {
            throw new EntityAlreadyExistsException<User>(existingUser);
        }
    }
}
