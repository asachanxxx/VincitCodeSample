﻿using System.Net;
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
    public class UpdatePhysicalAccountOpenRequestByRequestor : BaseFunction<UpdatePhysicalAccountOpenRequestByRequstorCommand, RowVersionResult>
    {
        public UpdatePhysicalAccountOpenRequestByRequestor(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UpdatePhysicalAccountOpenRequestByRequestor")]
        [OpenApiOperation(operationId: "UpdatePhysicalAccountOpenRequestByRequestor", "Account Open Requests")]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody("application/json", typeof(PhysicalAccountOpenRequestRequestorSectionDto))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "accounts/open-requests/physical/{guid}/requestor")] HttpRequest request, Guid guid, ILogger logger)
        {
            var payload = await request.GetFromJsonBody<PhysicalAccountOpenRequestRequestorSectionDto>();
            return await Run(new UpdatePhysicalAccountOpenRequestByRequstorCommand(guid, payload), logger);
        }
    }
}
