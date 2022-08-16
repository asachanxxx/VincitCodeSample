using Company.TxTool.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.CreatePicklistItem;

public class CreatePicklistItemCommandValidator : AbstractValidator<CreatePicklistItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CreatePicklistItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Name)
            .NotNull().NotEmpty().MaximumLength(255);
        RuleFor(x => x)
            .MustAsync(HaveUniqueName).WithMessage("The specified name already exists.");
    }

    public async Task<bool> HaveUniqueName(CreatePicklistItemCommand command, CancellationToken cancellationToken)
    {
        return await _context.PicklistItems
            .Where(i => i.Type == command.Type)
            .AllAsync(i => i.Name != command.Name, cancellationToken);
    }
}