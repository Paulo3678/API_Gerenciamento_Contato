using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;

namespace GerenciamentoContatos.Middlewares
{
    public class AuthMiddleware : IMiddlewareBase
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Do work that can write to the Response.
            if (context.Request.Path != "/login")
            {
                await Console.Out.WriteLineAsync("ABACATE");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { message = "É preciso logar para continuar" })); ;
                return;
            }
            await next.Invoke(context);
        }

    }
}
