using System;
using Company.TxTool.Application.Common.Exceptions;
using Company.TxTool.Application.SupportDocument;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.TxTool.FunctionApi.Functions;

public class BaseFunction<TRequest, TResponse> : ControllerBase where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IMediator _mediator;

    protected BaseFunction(IHttpContextAccessor httpContextAccessor, IMediator mediator)
    {
        _httpContextAccessor = httpContextAccessor;
        _mediator = mediator;
    }

    protected async Task<IActionResult> Run(TRequest request, ILogger logger)
    {
        try
        {
            var result = await _mediator.Send(request);

            if (typeof(TResponse).IsPrimitive)
            {
                return SendSuccessfulResult(logger);
            }

            if (typeof(TResponse).IsAssignableFrom(typeof(SupportDocumentDownloadDto)))
            {
                //var fileDto = (result as SupportDocumentDownloadDto)!;
                //var ms = new MemoryStream();
                //ms.Write(fileDto.FileContent, 0, fileDto.FileContent.Length);
                //ms.Seek(0, SeekOrigin.Begin);

                return SendSuccessfulResult((result as SupportDocumentDownloadDto)!);
            }

            return SendSuccessfulResult(result, logger);
        }
        catch (ValidationException validationException)
        {
            var result = new
            {
                message = "Validation failed.",
                errors = validationException.Errors.Select(x => new
                {
                    x.Key,
                    x.Value
                })
            };

            logger.LogError($"Validation errors occured: {result}");

            return new BadRequestObjectResult(result);
        }
        catch (UserNotFoundException ex)
        {
            return SendUnauthorizedResult(ex.Code, $"User '{ex.Email}' is not found in the system.", logger);
        }
        catch (UserNotActiveException ex)
        {
            return SendUnauthorizedResult(ex.Code, $"User '{ex.User.Name} ({ex.User.WorkEmail})' has been deactivated.", logger);
        }
        catch (NotFoundException ex)
        {
            return SendNotFoundResult(ex.Message, logger);
        }
        catch (TreasuryToolApplicationException ex)
        {
            return SendConflictResult(ex, logger);
        }
        catch (Exception ex)
        {
            var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}";
            var response = new
            {
                Success = false,
                Message = ex.InnerException == null ? ex.Message : $"{ex.Message} --> {ex.InnerException.Message}",
                ex.StackTrace
            };
            logger.LogError($"Failed response for {actionName} : {response}");

            if (ex.InnerException is not null && ex.InnerException is TreasuryToolApplicationException)
            {
                return SendConflictResult((ex.InnerException as TreasuryToolApplicationException)!, logger);
            }

            throw;
        }
    }

    protected virtual IActionResult SendSuccessfulResult(SupportDocumentDownloadDto fileDto)
    {
        _httpContextAccessor.HttpContext!.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
        return new FileContentResult(fileDto.FileContent, fileDto.MimeType)
        {
            FileDownloadName = fileDto.FileName
        };
    }

    [NonAction]
    protected virtual IActionResult SendConflictResult(TreasuryToolApplicationException ex, ILogger logger)
    {
        var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}";

        var response = new
        {
            Success = false,
            Code = ex.Code.ToString(),
            ex.Message
        };

        logger.LogError($"Failed response for {actionName} : {response}");

        return new ConflictObjectResult(response);
    }

    [NonAction]
    protected virtual IActionResult SendFailedValidationResult(dynamic validateRequest, string type, ILogger logger)
    {
        var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}_{type}";

        logger.LogError($"Failed request for {actionName} : {JsonConvert.SerializeObject(validateRequest.Value)}");

        var errors = (IList<ValidationFailure>)validateRequest.Errors;

        var errorList = errors.Select(e => new
        {
            Field = e.PropertyName,
            Error = e.ErrorMessage
        });

        var errResponse = new BadRequestObjectResult(new
        {
            Success = false,
            Message = errorList
        });

        logger.LogError($"Failed response for {actionName} : {JsonConvert.SerializeObject(errResponse)}");

        return errResponse;
    }

    [NonAction]
    protected virtual IActionResult SendNotFoundResult(string message, ILogger logger)
    {
        var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}";

        var response = new
        {
            Success = false,
            Message = message
        };

        logger.LogError($"Failed response for {actionName} : {response}");

        return new NotFoundObjectResult(response);
    }

    [NonAction]
    protected virtual IActionResult SendUnauthorizedResult(ExceptionCode code, string message, ILogger logger)
    {
        var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}";

        var response = new
        {
            Success = false,
            Code = code.ToString(),
            Message = message
        };

        logger.LogError($"Failed response for {actionName} : {response}");

        return new UnauthorizedObjectResult(response);
    }

    [NonAction]
    protected virtual IActionResult SendBadRequestObjectResult(string message, string type, ILogger logger)
    {
        var actionName = $"{_httpContextAccessor.HttpContext!.Request.Method}_{type}";

        var response = new
        {
            Success = false,
            Message = message
        };

        logger.LogError($"Failed response for {actionName} : {response}");

        return new BadRequestObjectResult(response);
    }

    [NonAction]
    protected virtual IActionResult SendSuccessfulResult(object? result, ILogger logger)
    {
        var method = _httpContextAccessor.HttpContext!.Request.Method;

        logger.LogInformation($"Successful response for {method} : {JsonConvert.SerializeObject(result)}");

        return new OkObjectResult(result);
    }

    [NonAction]
    protected virtual IActionResult SendSuccessfulResult(ILogger logger)
    {
        var method = _httpContextAccessor.HttpContext!.Request.Method;

        logger.LogInformation($"Successful response for {method}");

        return new OkResult();
    }
}
