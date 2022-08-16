using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.CreateAccountOpenRequest;

[AuthorizeForPermission(PermissionEnum.AorCreateNew)]
public record CreatePhysicalAccountOpenRequestCommand : IRequest<RowVersionResult>
{
    public CreatePhysicalAccountOpenRequestCommand(PhysicalAccountOpenRequestRequestorSectionDto payload)
    {
        Payload = payload;
    }

    public PhysicalAccountOpenRequestRequestorSectionDto Payload
    {
        get;
    }
}

public class CreatePhysicalAccountOpenRequestCommandHandler : IRequestHandler<CreatePhysicalAccountOpenRequestCommand, RowVersionResult>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateService;
    public readonly IMapper _mapper;

    public CreatePhysicalAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IDateTime dateService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateService = dateService;
        _mapper = mapper;
    }

    public async Task<RowVersionResult> Handle(CreatePhysicalAccountOpenRequestCommand command, CancellationToken cancellationToken)
    {
        var entity = new PhysicalAccountOpenRequest(_currentUserService.User.UserID, _dateService.TenantLocalToday);
        _mapper.Map(command.Payload, entity);

        _context.AccountOpenRequests.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new RowVersionResult(entity);
    }
}
