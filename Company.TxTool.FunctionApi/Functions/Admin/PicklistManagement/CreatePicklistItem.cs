using System;
using System.Net;
using Company.TxTool.Application.Admin.PicklistManagement.Commands.CreateAccountType;
using Company.TxTool.Application.Admin.PicklistManagement.Commands.CreatePicklistItem;
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
    public class CreatePicklistItem : BaseFunction<CreatePicklistItemCommand, Unit>
    {
        public CreatePicklistItem(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("CreatePicklistItem")]
        [OpenApiOperation(operationId: "CreatePicklistItem", "Picklists")]
        [OpenApiParameter("type", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiRequestBody("application/json", typeof(CreatePicklistItemCommand))]
        [OpenApiResponseWithoutBody(HttpStatusCode.OK)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "picklists/{type}/items")] HttpRequest request, string type, ILogger logger)
        {
            if (PicklistTypeEnum.TryFromName(type, true, out var picklistType))
            {
                switch (picklistType.Name)
                {
                    case nameof(PicklistTypeEnum.AccountType):
                        var accountType = await request.GetFromJsonBody<CreateAccountTypeCommand>();
                        accountType.Type = picklistType;
                        return await Run(accountType, logger);

                    default:
                        var picklistItem = await request.GetFromJsonBody<CreatePicklistItemCommand>();
                        picklistItem.Type = picklistType;
                        return await Run(picklistItem, logger);
                }
            }

            return SendBadRequestObjectResult("Picklist Type is invalid.", type, logger);
        }
    }
}
