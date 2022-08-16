using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.FunctionApi.Functions.Admin.UserManagement;

public class GetRoles : BaseFunction<GetApplicationRolesQuery, IEnumerable<ApplicationRoleDto>>
{
    public GetRoles(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetRoles")]
    [OpenApiOperation(operationId: "GetRoles", "Security")]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<ApplicationRoleDto>))]
    public async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "roles")] HttpRequest request, ILogger logger)
    {
        return await Run(new GetApplicationRolesQuery(), logger);
    }
}