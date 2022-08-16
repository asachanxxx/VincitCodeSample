using System;
using System.Net;
using Company.TxTool.Application.SupportDocument;
using Company.TxTool.Application.SupportDocument.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.SupportDocument
{
    public class UploadSupportDocument : BaseFunction<UploadSupportDocumentCommand, SupportDocumentDto>
    {
        public UploadSupportDocument(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("UploadSupportDocument")]
        [OpenApiOperation(operationId: "UploadSupportDocument", "Support Documents")]
        [OpenApiRequestBody("multipart/form-data", typeof(string))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(SupportDocumentDto))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "support-documents")] HttpRequest request, ILogger logger)
        {
            return await Run(new UploadSupportDocumentCommand(request.Form.Files, await request.ReadFormAsync()), logger);
        }
    }
}
