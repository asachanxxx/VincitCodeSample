using System;
using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Queries.GetVirtualAccountOpenRequest;
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
    public class GetVirtualAccountOpenRequest : BaseFunction<GetVirtualAccountOpenRequestQuery, VirtualAccountOpenRequestDto>
    {
        public GetVirtualAccountOpenRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("GetVirtualAccountOpenRequest")]
        [OpenApiOperation(operationId: "GetVirtualAccountOpenRequest", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(VirtualAccountOpenRequestDto))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "accounts/open-requests/virtual/{guid}")] HttpRequest request, Guid guid, ILogger logger)
        {
            return await Run(new GetVirtualAccountOpenRequestQuery(guid), logger);
        }
    }
}
