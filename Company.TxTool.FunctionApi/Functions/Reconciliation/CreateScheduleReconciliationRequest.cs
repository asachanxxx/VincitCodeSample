using System.Net;
using Company.TxTool.Application.Reconciliation.Commands;
using Company.TxTool.FunctionApi.Extensions;
using Cushwake.TreasuryTool.Application.AccountOpenRequest.Commands.CreateAccountOpenRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Reconciliation
{
    public class CreateScheduleReconciliationRequest : BaseFunction<CreateScheduleReconciliationRequestCommand, Unit>
    {
        public CreateScheduleReconciliationRequest(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("CreateScheduleReconciliationRequest")]
        [OpenApiOperation(operationId: "CreateScheduleReconciliationRequest", "Reconciliation Schedule Requests")]
        [OpenApiRequestBody("application/json", typeof(CreateScheduleReconciliationRequestCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "reconciliation/Schedule")] HttpRequest request, ILogger logger)
        {
            var Schedulet = await request.GetFromJsonBody<CreateScheduleReconciliationRequestCommand>();
            return await Run(Schedulet, logger);
        }
    }
}