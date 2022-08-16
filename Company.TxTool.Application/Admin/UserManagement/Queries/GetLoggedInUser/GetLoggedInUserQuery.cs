using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using MediatR;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetLoggedInUser;

public record GetLoggedInUserQuery : IRequest<UserLiteDto>
{
}

public class GetUserQueryHandler : IRequestHandler<GetLoggedInUserQuery, UserLiteDto>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(ICurrentUserService currentUserService, IMapper mapper)
    {
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public Task<UserLiteDto> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_mapper.Map<UserLiteDto>(_currentUserService.User));
    }
}