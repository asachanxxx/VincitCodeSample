using System;
using System.Net;
using Company.TxTool.Application.Admin.PicklistManagement.Commands.UpdatePicklistItem;
using Company.TxTool.FunctionApi.Extensions;
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
    public class UpdatePicklistItem : BaseFunction<UpdatePicklistItemCommand, Unit>
    {
        public UpdatePicklistItem(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UpdatePicklistItem")]
        [OpenApiOperation(operationId: "UpdatePicklistItem", "Picklists")]
        [OpenApiParameter("type", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiRequestBody("application/json", typeof(UpdatePicklistItemCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "PUT", Route = "picklists/{type}/items/{id}")] HttpRequest request, string type, int id, ILogger logger)
        {
            if (PicklistTypeEnum.TryFromName(type, true, out var picklistType))
            {
                switch (picklistType.Name)
                {
                    case nameof(PicklistTypeEnum.AccountType):
                        var accountType = await request.GetFromJsonBody<UpdateAccountTypeCommand>();
                        accountType.Id = id;
                        accountType.Type = picklistType;
                        return await Run(accountType, logger);

                    default:
                        var picklistItem = await request.GetFromJsonBody<UpdatePicklistItemCommand>();
                        picklistItem.Id = id;
                        picklistItem.Type = picklistType;
                        return await Run(picklistItem, logger);
                }
            }

            return SendBadRequestObjectResult("Picklist Type is invalid.", type, logger);
        }
    }
}
