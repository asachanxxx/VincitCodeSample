using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetUsers;
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
    public class GetUsers : BaseFunction<GetUsersPaginatedQuery, IEnumerable<UserListItemDto>>
    {
        public GetUsers(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("GetUsers")]
        [OpenApiOperation(operationId: "GetUsers", "Security")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(IEnumerable<UserListItemDto>))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "users")] HttpRequest request, ILogger logger)
        {
            return await Run(new GetUsersPaginatedQuery(), logger);
        }
    }
}