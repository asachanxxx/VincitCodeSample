using System;
using System.Net;
using Company.TxTool.Application.Admin.UserManagement.Commands.UpdateUser;
using Company.TxTool.FunctionApi.Extensions;
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
    [ApiExplorerSettings(GroupName = "Security")]
    public class UpdateUser : BaseFunction<UpdateUserCommand, Unit>
    {
        public UpdateUser(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UpdateUser")]
        [OpenApiOperation(operationId: "UpdateUser", "Security")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody("application/json", typeof(UpdateUserCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "PUT", Route = "users/{guid}")] HttpRequest request, Guid guid, ILogger logger)
        {
            var user = await request.GetFromJsonBody<UpdateUserCommand>();
            user.Guid = guid;
            return await Run(user, logger);
        }
    }
}
