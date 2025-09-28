using System.Net;
using System.Text.Json;

namespace PersonCRUD.Server.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch
            {
                // TODO: Salvar o erro e a requisição enviada e um log para identificar o problema posteriormente.
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Something went wrong in the server");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new
            {
                error = message,
                status = statusCode
            });

            return context.Response.WriteAsync(result);
        }
    }
}
