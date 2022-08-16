using System;
using System.Net;
using Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.FunctionApi.Functions.Admin.PicklistManagement;

public class GetPicklistTypes : BaseFunction<GetPicklistTypesQuery, IEnumerable<PicklistTypeDto>>
{
    public GetPicklistTypes(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetPicklistTypes")]
    [OpenApiOperation(operationId: "GetPicklistTypes", "Picklists")]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<PicklistTypeDto>))]
    public async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "picklists/types")] HttpRequest request, ILogger logger)
    {
        return await Run(new GetPicklistTypesQuery(), logger);
    }
}
