using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.AccountOpenRequest.Commands.UpdateAccountOpenRequest;
using Company.TxTool.Application.Common.Models;
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
    public class UpdatePhysicalAccountOpenRequestByReviewer : BaseFunction<UpdatePhysicalAccountOpenRequestByReviewerCommand, RowVersionResult>
    {
        public UpdatePhysicalAccountOpenRequestByReviewer(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UpdatePhysicalAccountOpenRequestByReviewer")]
        [OpenApiOperation(operationId: "UpdatePhysicalAccountOpenRequestByReviewer", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody("application/json", typeof(PhysicalAccountOpenRequestReviewerSectionDto))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "accounts/open-requests/physical/{guid}/reviewer")] HttpRequest request, Guid guid, ILogger logger)
        {
            var payload = await request.GetFromJsonBody<PhysicalAccountOpenRequestReviewerSectionDto>();
            return await Run(new UpdatePhysicalAccountOpenRequestByReviewerCommand(guid, payload), logger);
        }
    }
}
