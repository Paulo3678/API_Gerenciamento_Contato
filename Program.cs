using GerenciamentoContatos.Data;
using GerenciamentoContatos.Middlewares;
using GerenciamentoContatos.Models;
using GerenciamentoContatos.Repositories;
using Microsoft.AspNetCore.Builder;
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

app.UseCustomMiddlewares();

app.Run();
