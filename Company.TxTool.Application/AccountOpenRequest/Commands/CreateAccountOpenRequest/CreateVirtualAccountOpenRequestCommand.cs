using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.CreateAccountOpenRequest;

[AuthorizeForPermission(PermissionEnum.AorCreateNew)]
public record CreateVirtualAccountOpenRequestCommand : IRequest<RowVersionResult>
{
    public CreateVirtualAccountOpenRequestCommand(VirtualAccountOpenRequestRequestorSectionDto payload)
    {
        Payload = payload;
    }
    public VirtualAccountOpenRequestRequestorSectionDto Payload
    {
        get;
    }
}

public class CreateVirtualAccountOpenRequestCommandHandler : IRequestHandler<CreateVirtualAccountOpenRequestCommand, RowVersionResult>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateService;
    public readonly IMapper _mapper;

    public CreateVirtualAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IDateTime dateService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateService = dateService;
        _mapper = mapper;
    }

    public async Task<RowVersionResult> Handle(CreateVirtualAccountOpenRequestCommand command, CancellationToken cancellationToken)
    {
        var entity = new VirtualAccountOpenRequest(_currentUserService.User.UserID, _dateService.TenantLocalToday);
        _mapper.Map(command.Payload, entity);

        _context.AccountOpenRequests.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new RowVersionResult(entity);
    }
}
