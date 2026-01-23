
namespace Catalog.API.Exceptions
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new
                {
                    message = "An unexpected error occurred.",
                    details = ex.Message
                };
                await context.Response.WriteAsJsonAsync(response);
            }

        }
    }
}
