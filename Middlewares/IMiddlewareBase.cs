namespace GerenciamentoContatos.Middlewares
{
    public interface IMiddlewareBase
    {
        public abstract Task InvokeAsync(HttpContext context, RequestDelegate next);

    }
}
