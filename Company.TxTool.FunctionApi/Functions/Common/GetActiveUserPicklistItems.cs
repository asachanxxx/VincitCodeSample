using System;
using System.Net;
using Company.TxTool.Application.Common.Queries;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Common;

public class GetActiveUserPicklistItems : BaseFunction<GetActiveUserPicklistItemsQuery, IEnumerable<UserPicklistItemDto>>
{
    public GetActiveUserPicklistItems(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetActiveUserPicklistItems")]
    [OpenApiOperation(operationId: "GetActiveUserPicklistItems", "Common")]
    [OpenApiParameter("type", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<UserPicklistItemDto>))]
    public async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "users/{type}/active-items")] HttpRequest request, string type, ILogger logger)
    {
        if (UserPicklistTypeEnum.TryFromName(type, true, out var picklistType))
        {
            return await Run(new GetActiveUserPicklistItemsQuery(picklistType), logger);
        }

        return SendBadRequestObjectResult("User Picklist Type is invalid.", type, logger);
    }
}
