using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.AccountOpenRequest;

public class GetAccountOpenRequests : BaseFunction<GetAccountOpenRequestsPaginatedQuery, List<AccountOpenRequestListItemDto>>
{
    public GetAccountOpenRequests(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetAccountOpenRequests")]
    [OpenApiOperation(operationId: "GetAccountOpenRequests", "Account Open Requests")]
    [OpenApiParameter("PageNumber", In = ParameterLocation.Query, Required = true, Type = typeof(int))]
    [OpenApiParameter("PageSize", In = ParameterLocation.Query, Required = true, Type = typeof(int))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(List<AccountOpenRequestListItemDto>))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "accounts/open-requests")] HttpRequest request, ILogger logger)
    {
        return await Run(new GetAccountOpenRequestsPaginatedQuery(), logger);
    }
}