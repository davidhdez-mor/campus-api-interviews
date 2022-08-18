using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InterviewAPI.Api.Filters
{
    public class TruncatedFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            await next();
            string body = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
            Console.WriteLine(body);
        }

        private bool IsAValidString(string text)
        {
            return text.Length < 255;
        }
    }
}