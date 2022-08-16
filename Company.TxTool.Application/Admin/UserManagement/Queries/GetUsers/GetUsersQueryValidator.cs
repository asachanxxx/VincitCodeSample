using FluentValidation;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetUsers
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersPaginatedQuery>
    {
        public GetUsersQueryValidator()
        {
            //RuleFor(x => x.PageNumber)
            //      .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            //RuleFor(x => x.PageSize)
            //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}