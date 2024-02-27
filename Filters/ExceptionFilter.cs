using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FootballPlayersCatalog.Core.Exceptions;

namespace FootballPlayersCatalog.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundResult();
            }
            else if (context.Exception is ArgumentNullException)
            {
                context.Result = new BadRequestObjectResult(new { error = "Request cannot be null" });
            }
            else if (context.Exception is DbUpdateException)
            {
                context.Result = new BadRequestObjectResult(new { error = "Error in db" });
            }
            else if (context.Exception is Exception)
            {
                context.Result = new StatusCodeResult(500);
            }
            context.ExceptionHandled = true;
        }
    }
}
