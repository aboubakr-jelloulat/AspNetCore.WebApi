using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DURC.Filters
{
    public class LogActiviteFilter : IActionFilter
    {
        private readonly ILogger<LogActiviteFilter> _logger;

        public LogActiviteFilter(ILogger<LogActiviteFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.Result = new NotFoundResult();

            // Runs BEFORE action method
            _logger.LogInformation($"Executing action {context.ActionDescriptor.DisplayName}" +
                $" on controller {context.Controller}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Runs AFTER action method
            Console.WriteLine("After action execution");
        }

    }
}
