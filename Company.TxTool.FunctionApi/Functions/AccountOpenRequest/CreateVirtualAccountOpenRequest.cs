using System.Net;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.AccountOpenRequest.Commands.CreateAccountOpenRequest;
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
    public class CreateVirtualAccountOpenRequest : BaseFunction<CreateVirtualAccountOpenRequestCommand, RowVersionResult>
    {
        public CreateVirtualAccountOpenRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("CreateVirtualAccountOpenRequest")]
        [OpenApiOperation(operationId: "CreateVirtualAccountOpenRequest", "Account Open Requests")]
        [OpenApiRequestBody("application/json", typeof(CreateVirtualAccountOpenRequestCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "accounts/open-requests/virtual")] HttpRequest request, ILogger logger)
        {
            var payload = await request.GetFromJsonBody<VirtualAccountOpenRequestRequestorSectionDto>();
            return await Run(new CreateVirtualAccountOpenRequestCommand(payload), logger);
        }
    }
}