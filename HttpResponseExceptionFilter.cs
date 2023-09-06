using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class HttpResponseExceptionFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        context.Result = new ObjectResult(new Exception("Unhandled exception: " + (context?.Exception?.GetType()?.ToString())))
        {
            StatusCode = 500,
        };
    }
}