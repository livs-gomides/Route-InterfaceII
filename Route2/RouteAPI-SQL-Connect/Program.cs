using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data; // Certifique-se de que este namespace corresponde ao nome do seu projeto e pasta

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// ADICIONE A CONFIGURAÇÃO DO BANCO DE DADOS AQUI
builder.Services.AddDbContext<RouteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RouteCloudDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();