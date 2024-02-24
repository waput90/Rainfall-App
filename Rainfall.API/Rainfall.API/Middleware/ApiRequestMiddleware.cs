using Newtonsoft.Json;
using Rainfall.API.Models;

namespace Rainfall.API.Middleware
{
    public class ApiRequestMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Check the culture value
            var count = Convert.ToInt32(context.Request.Query["count"].ToString());

            if (count < 1 || count > 100)
            {
                // bad request
                context.Response.StatusCode = 400;
                ErrorResponse problem = new()
                {
                    description = "Invalid count input",
                    error_schema = new()
                    {
                        description = "Invalid count input",
                        title = "Error"
                    }
                };

                string serializeError = JsonConvert.SerializeObject(problem);

                await context.Response.WriteAsync(serializeError);

                context.Response.ContentType = "application/json";
                
                return;
            }
            
            await next(context);
        }
    }
}
