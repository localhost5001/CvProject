using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CvProject.WebApp;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        _logger.LogCritical(context.Exception, "Unhandled exception");

        var error = new ErrorDetails(StatusCodes.Status500InternalServerError, "Something went wrong! Internal Server Error.");
        context.Result = new JsonResult(error);
    }
}
