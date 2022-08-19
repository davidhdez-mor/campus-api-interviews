using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InterviewAPI.Api.Filters
{
    public class TruncatedFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            await next();
            var body = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
            Console.WriteLine(body);
        }
    }
}