using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Commands.UpdateAccountOpenRequest;
using Company.TxTool.FunctionApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.AccountOpenRequest
{
    public class UpdateVirtualAccountOpenRequestByReviewer : BaseFunction<UpdateVirtualAccountOpenRequestByReviewerCommand, Unit>
    {
        public UpdateVirtualAccountOpenRequestByReviewer(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UpdateVirtualAccountOpenRequestByReviewer")]
        [OpenApiOperation(operationId: "UpdateVirtualAccountOpenRequestByReviewer", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody("application/json", typeof(UpdateVirtualAccountOpenRequestByRequestorCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "accounts/open-requests/virtual/{guid}/reviewer")] HttpRequest request, Guid guid, ILogger logger)
        {
            var command = await request.GetFromJsonBody<UpdateVirtualAccountOpenRequestByReviewerCommand>();
            command.Guid = guid;
            return await Run(command, logger);
        }
    }
}