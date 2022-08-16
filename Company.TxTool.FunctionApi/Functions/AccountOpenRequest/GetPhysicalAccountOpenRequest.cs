using System;
using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Queries.GetPhysicalAccountOpenRequest;
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
    public class GetPhysicalAccountOpenRequest : BaseFunction<GetPhysicalAccountOpenRequestQuery, PhysicalAccountOpenRequestDto>
    {
        public GetPhysicalAccountOpenRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("GetPhysicalAccountOpenRequest")]
        [OpenApiOperation(operationId: "GetPhysicalAccountOpenRequest", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(PhysicalAccountOpenRequestDto))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "accounts/open-requests/physical/{guid}")] HttpRequest request, Guid guid, ILogger logger)
        {
            return await Run(new GetPhysicalAccountOpenRequestQuery(guid), logger);
        }
    }
}
