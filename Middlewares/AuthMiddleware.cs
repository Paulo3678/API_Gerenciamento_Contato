using GerenciamentoContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Text.Json;

namespace GerenciamentoContatos.Middlewares
{
    public class AuthMiddleware : IMiddlewareBase
    {
        private ITokenManager _tokenManager;

        public AuthMiddleware(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path != "/login")
            {
                await ReturnMessage(context, "É preciso logar para continuar");
                return;
            }

            var authHeader = context.Request.Headers["authorization"];
            if (authHeader.IsNullOrEmpty())
            {
                await ReturnMessage(context, "É preciso informar o token de acesso para continuar");
                return;
            }

            _tokenManager.Validate();

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
