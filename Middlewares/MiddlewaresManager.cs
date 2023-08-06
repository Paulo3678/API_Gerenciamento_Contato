namespace GerenciamentoContatos.Middlewares
{
    public static class MiddlewaresManager
    {
        // Permite que você chame esse método como se fosse um método de instância da classe.
        public static void UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.Use(new AuthMiddleware().InvokeAsync);
        }
    }
}
