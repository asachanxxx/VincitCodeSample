using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Commands.StartReviewAccountOpenRequest;
using Company.TxTool.Application.Common.Models;
using Company.TxTool.FunctionApi.Functions;
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
    public class StartReviewAccountOpenRequest : BaseFunction<StartReviewAccountOpenRequestCommand, RowVersionResult>
    {
        public StartReviewAccountOpenRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("StartReviewAccountOpenRequest")]
        [OpenApiOperation(operationId: "StartReviewAccountOpenRequest", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "PUT", Route = "accounts/open-requests/{guid}/start-review")] HttpRequest request, Guid guid, ILogger logger)
        {
            return await Run(new StartReviewAccountOpenRequestCommand(guid), logger);
        }
    }
}
