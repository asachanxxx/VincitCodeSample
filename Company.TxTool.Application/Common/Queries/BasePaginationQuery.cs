using Company.TxTool.Application.Common.Models;
using MediatR;

namespace Company.TxTool.Application.Common.Queries;

public record BasePaginationQuery<T> : IRequest<PaginatedList<T>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}