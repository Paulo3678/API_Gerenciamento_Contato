using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace GerenciamentoContatos.Middlewares
{
    public class AuthMiddleware : IMiddleware
    {

        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("AbaCATE");
            await _next(context);
         
        }
    }
}
