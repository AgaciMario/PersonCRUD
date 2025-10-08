using PersonCRUD.Domain.Exceptions;
using PersonCRUD.Server.Records;
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
            //TODO: Padronizar casos de exception por falha na deserialização.
            //TODO: Validar o uso do nameof para os casos de bad request pois os nomes estão com inicial maíscula
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
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

            var result = JsonSerializer.Serialize(new ErrorResponse
            (
                Error: message,
                StatusCode: (int)statusCode
            ));

            return context.Response.WriteAsync(result);
        }
    }
}
