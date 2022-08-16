using System;
using System.Net;
using Company.TxTool.Application.Admin.PicklistManagement.Commands.DeletePicklistItem;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.Admin.PicklistManagement
{
    public class DeletePicklistItem : BaseFunction<DeletePicklistItemCommand, Unit>
    {
        public DeletePicklistItem(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("DeletePicklistItem")]
        [OpenApiOperation(operationId: "DeletePicklistItem", "Picklists")]
        [OpenApiParameter("type", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "DELETE", Route = "picklists/{type}/items/{id}")] HttpRequest request, string type, int id, ILogger logger)
        {
            if (PicklistTypeEnum.TryFromName(type, true, out var picklistType))
            {
                return await Run(new DeletePicklistItemCommand(picklistType, id), logger);
            }

            return SendBadRequestObjectResult("Picklist Type is invalid.", type, logger);
        }
    }
}
