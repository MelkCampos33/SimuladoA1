using CadastroEstudanteApi.Data;
using CadastroEstudanteApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder
    .Services
    .AddDbContext<AppDbContext>(options =>
    options.
    UseSqlite("Data Source=BancoEstudante.db")
    );



var app = builder.Build();

if (app.Environment.IsDevelopment()) // ambiente de de desenvolvimento
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
