using System;
using System.Net;
using Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems;
using Company.TxTool.Application.Common.Queries;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Common;

public class GetActivePicklistItems : BaseFunction<GetActivePicklistItemsQuery, IEnumerable<PicklistItemDto>>
{
    public GetActivePicklistItems(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetActivePicklistItems")]
    [OpenApiOperation(operationId: "GetActivePicklistItems", "Common")]
    [OpenApiParameter("type", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<PicklistItemDto>))]
    public async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "picklists/{type}/active-items")] HttpRequest request, string type, ILogger logger)
    {
        if (PicklistTypeEnum.TryFromName(type, true, out var picklistType))
        {
            return await Run(new GetActivePicklistItemsQuery(picklistType), logger);
        }

        return SendBadRequestObjectResult("Picklist Type is invalid.", type, logger);
    }
}
