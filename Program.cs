using GerenciamentoContatos.Data;
using GerenciamentoContatos.Middlewares;
using GerenciamentoContatos.Models;
using GerenciamentoContatos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepositoryEntityFrame>();
builder.Services.AddScoped<ITokenManager, JwtTokenManager>();


var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<GerenciamentoContatosContext>(opts =>
{
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
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
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run();
