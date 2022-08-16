using System;
using System.Net;
using Company.TxTool.Application.SupportDocument;
using Company.TxTool.Application.SupportDocument.Queries;
using Company.TxTool.FunctionApi.Functions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Company.TxTool.FunctionApi.Functions.SupportDocument
{
    public class DownloadSupportDocument : BaseFunction<DownloadSupportDocumentQuery, SupportDocumentDownloadDto>
    {
        public DownloadSupportDocument(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [FunctionName("DownloadSupportDocument")]
        [OpenApiOperation(operationId: "DownloadSupportDocument", "Support Documents", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter("guid", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/octet-stream", typeof(FileResult))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "support-documents/{guid}")] HttpRequest request, Guid guid, ILogger logger)
        {
            return await Run(new DownloadSupportDocumentQuery(guid), logger);
        }
    }
}
