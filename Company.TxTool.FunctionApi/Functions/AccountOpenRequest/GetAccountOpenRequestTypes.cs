using System;
using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequestTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.AccountOpenRequest;

public class GetAccountOpenRequestTypes : BaseFunction<GetAccountOpenRequestTypesQuery, IEnumerable<AccountOpenRequestTypeDto>>
{
    public GetAccountOpenRequestTypes(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetAccountOpenRequestTypes")]
    [OpenApiOperation(operationId: "GetAccountOpenRequestTypes", "Account Open Requests")]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<AccountOpenRequestTypeDto>))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "accounts/open-requests/types")] HttpRequest request, ILogger logger)
    {
        return await Run(new GetAccountOpenRequestTypesQuery(), logger);
    }
}
