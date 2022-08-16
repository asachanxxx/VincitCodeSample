using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Admin.UserManagement;

public class GetRolePermissions : BaseFunction<GetRolePermissionsQuery, IEnumerable<PermissionDto>>
{
    public GetRolePermissions(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
    {
    }

    [FunctionName("GetRolePermissions")]
    [OpenApiOperation(operationId: "GetRolePermissions", "Security")]
    [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<PermissionDto>))]
    public async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "roles/{id}/permissions")] HttpRequest request, int id, ILogger logger)
    {
        return await Run(new GetRolePermissionsQuery(id), logger);
    }
}