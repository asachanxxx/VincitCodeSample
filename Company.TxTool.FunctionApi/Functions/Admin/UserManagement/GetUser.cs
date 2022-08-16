using System;
using System.Net;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Admin.UserManagement
{
    public class GetUser : BaseFunction<GetUserQuery, UserDto>
    {
        public GetUser(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("GetUser")]
        [OpenApiOperation(operationId: "GetUser", "Security")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(UserDto))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "users/{guid}")] HttpRequest request, Guid guid, ILogger logger)
        {
            return await Run(new GetUserQuery(guid), logger);
        }
    }
}
