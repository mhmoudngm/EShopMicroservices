
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
                if (ex.GetType() == typeof(FluentValidation.ValidationException))
                {
                    var validationException = (FluentValidation.ValidationException)ex;
                    var response = new
                    {
                        message = "One or more validation failures have occurred.",
                        //details = ex.Message,
                        errors = validationException.Errors.Select(err => new
                        {
                            Property = err.PropertyName,
                            Message = err.ErrorMessage,
                        }).ToList()
                    };

                    await context.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    var response = new
                    {
                        message = "An unexpected error occurred.",
                        details = ex.Message,
                    };
                    await context.Response.WriteAsJsonAsync(response);
                }
            }

        }
    }
}
