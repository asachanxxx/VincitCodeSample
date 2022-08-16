using System;
using System.Net;
using System.Threading.Tasks;
using Company.TxTool.Application.Admin.UserManagement.Commands.CreateUser;
using Company.TxTool.FunctionApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.FunctionApi.Functions.Admin.UserManagement
{
    public class CreateUser : BaseFunction<CreateUserCommand, int>
    {
        public CreateUser(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", "Security")]
        [OpenApiRequestBody("application/json", typeof(CreateUserCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "users")] HttpRequest request, ILogger logger)
        {
            var user = await request.GetFromJsonBody<CreateUserCommand>();
            return await Run(user, logger);
        }
    }
}