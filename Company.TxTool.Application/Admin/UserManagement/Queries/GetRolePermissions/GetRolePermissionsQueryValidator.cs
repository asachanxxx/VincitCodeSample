using FluentValidation;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetRolePermissions;

public class GetRolePermissionsQueryValidator : AbstractValidator<GetRolePermissionsQuery>
{
    public GetRolePermissionsQueryValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThanOrEqualTo(1).WithMessage("RoleId at least greater than or equal to 1.");
    }
}