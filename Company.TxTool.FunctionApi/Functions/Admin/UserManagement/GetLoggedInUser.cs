using System;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetLoggedInUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.FunctionApi.Functions.Admin.UserManagement
{
    public class GetLoggedInUser : BaseFunction<GetLoggedInUserQuery, UserLiteDto>
    {
        public GetLoggedInUser(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("GetLoggedInUser")]
        [OpenApiOperation(operationId: "GetLoggedInUser", "Security")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(UserLiteDto))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "users/me")] HttpRequest request, ILogger logger)
        {
            return await Run(new GetLoggedInUserQuery(), logger);
        }
    }
}