using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.AccountOpenRequest.Commands.RejectAccountOpenRequest;
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
    public class RejectPhysicalAccountOpenRequest : BaseFunction<RejectPhysicalAccountOpenRequestCommand, RowVersionResult>
    {
        public RejectPhysicalAccountOpenRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("RejectPhysicalAccountOpenRequest")]
        [OpenApiOperation(operationId: "RejectPhysicalAccountOpenRequest", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody("application/json", typeof(PhysicalAccountOpenRequestReviewerSectionDto))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "PUT", Route = "accounts/open-requests/physical/{guid}/reject")] HttpRequest request, Guid guid, ILogger logger)
        {
            var payload = await request.GetFromJsonBody<PhysicalAccountOpenRequestReviewerSectionDto>();
            return await Run(new RejectPhysicalAccountOpenRequestCommand(guid, payload), logger);
        }
    }
}
