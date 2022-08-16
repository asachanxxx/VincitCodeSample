using AutoMapper;
using Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;

namespace Company.TxTool.Application.Common.Queries;

public record GetActivePicklistItemsQuery : GetPicklistItemsQuery
{
    public GetActivePicklistItemsQuery(PicklistTypeEnum type) : base(type)
    {
    }
}

public class GetActivePicklistItemsQueryHandler : IRequestHandler<GetActivePicklistItemsQuery, IEnumerable<PicklistItemDto>>
{
    private readonly GetPicklistQueryHandler _baseHandler;

    public GetActivePicklistItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _baseHandler = new GetPicklistQueryHandler(context, mapper);
    }

    public async Task<IEnumerable<PicklistItemDto>> Handle(GetActivePicklistItemsQuery request, CancellationToken cancellationToken)
    {
        return (await _baseHandler.Handle(request, cancellationToken)).Where(i => i.IsActive);
    }
}
