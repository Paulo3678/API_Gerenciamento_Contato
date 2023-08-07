using GerenciamentoContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Text.Json;

namespace GerenciamentoContatos.Middlewares
{
    public class AuthMiddleware : IMiddlewareBase
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/login")
            {
                await next.Invoke(context);
                return;
            }

            var authHeader = context.Request.Headers["authorization"];
            await Console.Out.WriteLineAsync();
            if (authHeader.IsNullOrEmpty())
            {
                await ReturnMessage(context, "É preciso informar o token de acesso para continuar");
                return;
            }
            string token = authHeader.ToString().Replace("Bearer ", "");

            JwtTokenManager tokenManager = new JwtTokenManager();

            bool tokenIsValid = tokenManager.Validate(token);

            if (!tokenIsValid)
            {
                await ReturnMessage(context, "Token inválido");
                return;
            }
            await next.Invoke(context);
        }

        private static async Task ReturnMessage(HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { message = message }));
        }
    }
}
