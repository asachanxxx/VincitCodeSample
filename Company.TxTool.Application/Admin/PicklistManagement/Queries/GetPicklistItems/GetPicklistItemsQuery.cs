using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems;

public record GetPicklistItemsQuery : IRequest<IEnumerable<PicklistItemDto>>
{
    public GetPicklistItemsQuery(PicklistTypeEnum type)
    {
        Type = type;
    }

    public PicklistTypeEnum Type
    {
        get; private set;
    }
}

public class GetPicklistQueryHandler : IRequestHandler<GetPicklistItemsQuery, IEnumerable<PicklistItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPicklistQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PicklistItemDto>> Handle(GetPicklistItemsQuery request, CancellationToken cancellationToken)
    {
        switch (request.Type.Name)
        {
            case nameof(PicklistTypeEnum.AccountType):
                return await _context.PicklistItems.AsNoTracking()
                    .OfType<AccountType>()
                    .OrderBy(i => i.MemberOrderKey)
                    .ThenBy(i => i.Name)
                    .ProjectTo<AccountTypeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            case nameof(PicklistTypeEnum.Currency):
                return await _context.PicklistItems.AsNoTracking()
                    .OfType<Currency>()
                    .OrderBy(i => i.MemberOrderKey)
                    .ThenBy(i => i.Name)
                    .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            default:
                return await _context.PicklistItems.AsNoTracking()
                    .Where(i => i.Type == request.Type)
                    .OrderBy(i => i.MemberOrderKey)
                    .ThenBy(i => i.Name)
                    .ProjectTo<PicklistItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        }
    }
}
