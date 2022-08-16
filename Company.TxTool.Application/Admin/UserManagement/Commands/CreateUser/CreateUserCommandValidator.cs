using FluentValidation;

namespace Company.TxTool.Application.Admin.UserManagement.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().MaximumLength(255);
        RuleFor(x => x.FirstName)
            .MaximumLength(255);
        RuleFor(x => x.LastName)
            .MaximumLength(255);
        RuleFor(x => x.UserGraphId).Must(guid =>
        {
            var value = Guid.Empty;
            var isValid = Guid.TryParse(guid, out value);
            return isValid && value != Guid.Empty;
        })
            .WithMessage("The UserGraphId must be a valid GUID.");
    }
}